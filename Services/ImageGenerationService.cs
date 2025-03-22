using OpenAI.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GenAI_ImageGenerator.Services
{
    public class ImageGenerationService 
    {
        private static ImageClient _client;

        public ImageGenerationService() { }

        public async Task<string> GenerateImageFromPrompt(string prompt)
        {
            DotNetEnv.Env.Load();
            var apiKey = Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.Process);
            
            //_client = new ImageClient("dall-e-3", "dsdsds");

            //ImageGenerationOptions options = new ImageGenerationOptions
            //{
            //    Quality = GeneratedImageQuality.Standard,
            //    Size = GeneratedImageSize.W1792xH1024,
            //    Style = GeneratedImageStyle.Vivid,
            //    ResponseFormat = GeneratedImageFormat.Bytes
            //};

            //GeneratedImage image = await _client.GenerateImageAsync("", options);

            return "https://manlybattery.com/wp-content/uploads/2022/03/Introduction-of-flashlight.jpg";
        }
    }
}
