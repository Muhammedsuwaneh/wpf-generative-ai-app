using System.Windows.Input;

namespace GenAI_ImageGenerator.ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        ICommand CloseWindowCommand { get; }
        ICommand CloseWindowOnKeyPressCommand { get; }
        bool Listening { get; set; }
        ICommand MinimizeWindowCommand { get; }
        ICommand SendRequestCommand { get; }
        ICommand SpeechToTextCommand { get; }
        string UserPrompt { get; set; }
    }
}