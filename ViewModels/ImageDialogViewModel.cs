using GenAI_ImageGenerator.Commands;
using GenAI_ImageGenerator.Commands.Utilities;
using GenAI_ImageGenerator.Views.Templates.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GenAI_ImageGenerator.ViewModels
{
    public class ImageDialogViewModel : ViewModelBase, IImageDialogViewModel
    {

        private string _generatedImageUrl = string.Empty;
        public string GeneratedImageUrl
        {
            get => _generatedImageUrl;
            set
            {
                if (_generatedImageUrl != value)
                {
                    _generatedImageUrl = value;
                    OnPropertyChanged(nameof(GeneratedImageUrl));
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
            MessageBox.Show("Dowloading .....");
        }

        public ImageDialogViewModel() => ProcessUserRequest();

        private void ProcessUserRequest()
        {
            Task.Delay(5000);
            //ProcessingImageGenerationRequest = false;
            //ImageGenerated = true;
        }

        private void CloseWindow(object obj)
        {
            if (obj is ImageDialog window)
                window.Close();
        }
    }
}
