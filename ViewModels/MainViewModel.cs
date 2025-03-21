using GenAI_ImageGenerator.Commands;
using GenAI_ImageGenerator.Commands.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GenAI_ImageGenerator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
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

        public MainViewModel()
        {
                
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
