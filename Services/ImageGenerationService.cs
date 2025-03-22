using GenAI_ImageGenerator.Commands.Utilities;
using GenAI_ImageGenerator.Factory.Interfaces;
using GenAI_ImageGenerator.Services.Contracts;
using GenAI_ImageGenerator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GenAI_ImageGenerator.Services
{
    public class ImageGenerationService : IImageGenerationService
    {
        private string API_KEY = "";
        private static ImageClient _client;

        public ImageGenerationService() { }

        public async Task<BinaryData?> GenerateImageFromPrompt(string prompt)
        {
            _client = new ImageClient("dall-e-3", API_KEY);

            ImageGenerationOptions options = new ImageGenerationOptions
            {
                Quality = GeneratedImageQuality.Standard,
                Size = GeneratedImageSize.W1792xH1024,
                Style = GeneratedImageStyle.Vivid,
                ResponseFormat = GeneratedImageFormat.Bytes
            };

            GeneratedImage response = await _client.GenerateImageAsync(prompt, options);
            var image = response.ImageBytes;

            return image;
        }
    }
}
