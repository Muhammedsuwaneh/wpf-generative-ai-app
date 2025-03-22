namespace GenAI_ImageGenerator.Services.Contracts
{
    public interface IImageGenerationService
    {
        Task<BinaryData?> GenerateImageFromPrompt(string prompt);
    }
}