using GenAI_ImageGenerator.Commands;
using GenAI_ImageGenerator.Commands.Utilities;
using GenAI_ImageGenerator.Factory.Interfaces;
using GenAI_ImageGenerator.Services;
using GenAI_ImageGenerator.Views.Templates.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GenAI_ImageGenerator.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private string _userPrompt = string.Empty;
        public string UserPrompt
        {
            get => _userPrompt;
            set
            {
                if(_userPrompt != value)
                {
                    _userPrompt = value;
                    OnPropertyChanged(nameof(UserPrompt));
                }
            }
        }

        private bool _listening = false;
        public bool Listening
        {
            get => _listening;
            set
            {
                if (_listening != value)
                {
                    _listening = value;
                    OnPropertyChanged(nameof(Listening));
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

        RelayCommand<KeyEventArgs> _closeWindowOnKeyPressCommand;
        public ICommand CloseWindowOnKeyPressCommand
        {
            get
            {
                if (_closeWindowOnKeyPressCommand == null)
                    _closeWindowOnKeyPressCommand = new RelayCommand<KeyEventArgs>(CloseWindowOnEscapeKeyPress);
                return _closeWindowOnKeyPressCommand;
            }
        }

        RelayCommand<object> _minimizeWindowCommand;
        public ICommand MinimizeWindowCommand
        {
            get
            {
                if (_minimizeWindowCommand == null)
                    _minimizeWindowCommand = new RelayCommand<object>(MinimizeWindow);

                return _minimizeWindowCommand;
            }
        }


        RelayCommand<MouseButtonEventArgs> _speechToTextCommand;
        public ICommand SpeechToTextCommand
        {
            get
            {
                if (_speechToTextCommand == null)
                    _speechToTextCommand = new RelayCommand<MouseButtonEventArgs>(StartListening);
                return _speechToTextCommand;
            }
        }


        RelayCommand<MouseButtonEventArgs> _sendRequestCommand;
        public ICommand SendRequestCommand
        {
            get
            {
                if (_sendRequestCommand == null)
                    _sendRequestCommand = new RelayCommand<MouseButtonEventArgs>(SendRequest);
                return _sendRequestCommand;
            }
        }

        public MainViewModel() { }

        private void SendRequest(MouseButtonEventArgs args)
        {
            var imageGeneratorDialog = App.AppHost!.Services.GetRequiredService<ImageDialog>();

            if (imageGeneratorDialog != null)
                imageGeneratorDialog.ShowDialog();
        }

        private void StartListening(MouseButtonEventArgs args)
        {
            Listening = true; // show speech ui
            CognitiveServices.DetectSpeech();
            CognitiveServices.recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        }

        private void Recognizer_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            Listening = false;
            UserPrompt = e.Result.Text; 
        }

        private void CloseWindowOnEscapeKeyPress(KeyEventArgs e) => GetCurrentWindow().Close();

        private void CloseWindow(object obj)
        {
            if (obj is MainWindow window)
                window.Close();
        }

        private void MinimizeWindow(object obj)
        {
            if (obj is MainWindow window)
            {
                window.WindowState = System.Windows.WindowState.Minimized;
            }
        }
        private Window GetCurrentWindow() => Application.Current.MainWindow;
    }
}
