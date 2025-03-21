using System.Windows.Input;

namespace GenAI_ImageGenerator.ViewModels
{
    public interface IMainViewModel
    {
        ICommand CloseWindowCommand { get; }
        ICommand CloseWindowOnKeyPressCommand { get; }
        bool Listening { get; set; }
        ICommand MinimizeWindowCommand { get; }
        ICommand SendRequestCommand { get; }
        ICommand SpeechToTextCommand { get; }
    }
}