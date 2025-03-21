using GenAI_ImageGenerator.Commands;
using GenAI_ImageGenerator.Commands.Utilities;
using GenAI_ImageGenerator.Factory.Interfaces;
using GenAI_ImageGenerator.Services;
using GenAI_ImageGenerator.Views.Templates.Dialogs;
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

namespace GenAI_ImageGenerator.ViewModels
{
    public class ImageDialogViewModel : ViewModelBase, IImageDialogViewModel
    {
        private IAbstractFactory<ImageGenerationService> _factory;

        private string _generatedImageUri = string.Empty;

        public string GeneratedImageUri
        {
            get => _generatedImageUri;
            set
            {
                if (_generatedImageUri != value)
                {
                    _generatedImageUri = value;
                    OnPropertyChanged(nameof(GeneratedImageUri));
                }
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

        private async void DownloadImage(object obj)
        {
            if(GeneratedImageUri != null)
            {
                var downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                var savePath = Path.Combine(downloads, GenerateFilename());

                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(GeneratedImageUri);
                    await System.IO.File.WriteAllBytesAsync(savePath, imageBytes);
                }
            }
        }

        private string GenerateFilename() => "generated_image_" + Guid.NewGuid().ToString() + ".jpg";

        public ImageDialogViewModel(IAbstractFactory<ImageGenerationService> factory)
        {
            _factory = factory;
            Task.Run(() => ProcessUserRequest());
        }

        private async void ProcessUserRequest()
        {
            try
            {
                var imageUri = await _factory.Create().GenerateImageFromPrompt("");
                if(imageUri != null)
                {
                    GeneratedImageUri = imageUri;
                    ImageGenerated = true;
                }
                else
                {
                    throw new Exception("Image was not generated");
                }
            }
            catch (Exception ex)
            {
                // log errors
                ImageGenerated = false;
                Log.Logs.LogToFile(ex, Log.LogType.Warning);
                MessageBox.Show("Something went wrong. Image was not generated. Close this window and try again");
            }
            finally
            {
                ProcessingImageGenerationRequest = false;
            }
        }

        private void CloseWindow(object obj)
        {
            if (obj is ImageDialog window)
                window.Close();
        }
    }
}
