using System.Windows.Input;
using System.Windows.Media;

namespace GenAI_ImageGenerator.ViewModels
{
    public interface IImageDialogViewModel
    {
        ICommand CloseWindowCommand { get; }
        ICommand DownloadCommand { get; }
        ImageSource GeneratedImageSource { get; set; }
        bool ImageGenerated { get; set; }
        bool ProcessingImageGenerationRequest { get; set; }
    }
}