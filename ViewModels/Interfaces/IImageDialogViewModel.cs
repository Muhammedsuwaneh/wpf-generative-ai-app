using System.Windows.Input;

namespace GenAI_ImageGenerator.ViewModels
{
    public interface IImageDialogViewModel
    {
        ICommand CloseWindowCommand { get; }
        ICommand DownloadCommand { get; }
        string GeneratedImageUri { get; set; }
        bool ImageGenerated { get; set; }
        bool ProcessingImageGenerationRequest { get; set; }
    }
}