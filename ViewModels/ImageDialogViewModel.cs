using GenAI_ImageGenerator.Commands;
using GenAI_ImageGenerator.Commands.Utilities;
using GenAI_ImageGenerator.Factory.Interfaces;
using GenAI_ImageGenerator.Services;
using GenAI_ImageGenerator.ViewModels.Interfaces;
using GenAI_ImageGenerator.Views.Templates.Dialogs;
using MaterialDesignColors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using OpenAI;
using OpenAI.Images;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GenAI_ImageGenerator.ViewModels
{
    public class ImageDialogViewModel : ViewModelBase, IImageDialogViewModel
    {
        private readonly IMainViewModel _mainViewModel;
        private IAbstractFactory<ImageGenerationService> _factory;

        private bool _requestWasUnsuccessful = false;
        public bool RequestWasUnsuccessful
        {
            get => _requestWasUnsuccessful;
            set
            {
                if(_requestWasUnsuccessful != value)
                {
                    _requestWasUnsuccessful = value;
                    OnPropertyChanged(nameof(RequestWasUnsuccessful));  
                }
            }
        }


        private string _errorMessage = string.Empty;
        public string ErrorMesage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMesage));
                }
            }
        }

        private BinaryData _generatedImage;

        public BinaryData GeneratedImage
        {
            get => _generatedImage;
            set
            {
                if (_generatedImage != value)
                {
                    _generatedImage = value;
                    OnPropertyChanged(nameof(GeneratedImage));
                }
            }
        }

        private ImageSource _generatedImageSource;
        public ImageSource GeneratedImageSource
        {
            get => _generatedImageSource;
            set
            {
                _generatedImageSource = value;
                OnPropertyChanged(nameof(GeneratedImageSource));
            }
        }


        private bool _imageGenerated = false;
        public bool ImageGenerated
        {
            get => _imageGenerated;
            set
            {
                if (_imageGenerated != value)
                {
                    _imageGenerated = value;
                    OnPropertyChanged(nameof(ImageGenerated));
                }
            }
        }

        private bool _processingImageGenerationRequest = true;
        public bool ProcessingImageGenerationRequest
        {
            get => _processingImageGenerationRequest;
            set
            {
                if (_processingImageGenerationRequest != value)
                {
                    _processingImageGenerationRequest = value;
                    OnPropertyChanged(nameof(ProcessingImageGenerationRequest));
                }
            }
        }

        RelayCommand<object> _closeWindowCommand;
        public ICommand CloseWindowCommand
        {
            get
            {
                if (_closeWindowCommand == null)
                    _closeWindowCommand = new RelayCommand<object>(CloseWindow);

                return _closeWindowCommand;
            }

        }

        RelayCommand<object> _downloadCommand;
        public ICommand DownloadCommand
        {
            get
            {
                if (_downloadCommand == null)
                    _downloadCommand = new RelayCommand<object>(DownloadImage);
                return _downloadCommand;
            }
        }

        private void DownloadImage(object obj)
        {
            if(GeneratedImage != null)
            {
                Application.Current.Dispatcher.Invoke(new Action(async () =>
                {
                    var downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    var savePath = Path.Combine(downloads, GenerateFilename());

                    using (FileStream stream = File.OpenWrite(savePath))
                    {
                        GeneratedImage.ToStream().CopyTo(stream);
                        MessageBox.Show("Image saved to Downloads ✅");
                    }

                }));
            }
        }

        private string GenerateFilename() => "generated_image_" + Guid.NewGuid().ToString() + ".jpg";

        public ImageDialogViewModel(IAbstractFactory<ImageGenerationService> factory, IMainViewModel mainViewModel)
        {
            _factory = factory;
            _mainViewModel = mainViewModel;
            Task.Run(() => ProcessUserRequest());
        }

        private async void ProcessUserRequest()
        {
            try
            {
                var image = await _factory.Create().GenerateImageFromPrompt(_mainViewModel.UserPrompt);

                if(image != null)
                {
                    GeneratedImage = image;
                    // display image 
                    GeneratedImageSource = ConvertToImage(image.ToArray());
                    ImageGenerated = true;
                }
                else throw new Exception("Image was not generated");
            }
            catch (Exception ex)
            {
                ImageGenerated = false;
                RequestWasUnsuccessful = true;

                Log.Logs.LogToFile(ex, Log.LogType.Warning); // log errors
                ErrorMesage = "Something went wrong. Image was not generated. Close this window and try again";
            }
            finally
            {
                ProcessingImageGenerationRequest = false;
            }
        }

        private BitmapImage ConvertToImage(byte[] imageData)
        {
            using (var ms = new MemoryStream(imageData))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze(); // Important for UI thread safety
                return image;
            }
        }


        private void CloseWindow(object obj)
        {
            if (obj is ImageDialog window) window.Close();
        }
    }
}
