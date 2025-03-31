🖼️ WPF Generative AI Image Creator

![Screenshot](Screenshots/MainWindow.png)


📌 About the Application
This AI-powered image generation app transforms user input into stunning visuals using generative AI. Users can either type a prompt or use speech-to-text functionality to describe the image they want, and the app generates a unique AI image in seconds.

✨ Key Features
🎤 Speech-to-Text Image Generation
Users can simply speak their idea, and the app converts speech into text for AI image creation.

Supports multiple languages and accents for a seamless experience.

📝 Text-Based AI Image Generation
Users can enter a text prompt to generate high-quality AI-generated images.

Fine-tune creativity by adding details such as style, color, and mood.

Adjust parameters such as resolution, lighting, and composition.

🚀 Fast & Efficient Processing
Uses cutting-edge AI models to generate images quickly.

Optimized for both local processing and cloud-based AI inference.

📂 Image History & Export Options
Users can download their generated images.

⚙️ Prerequisites / how to run

```bash
# Clone the repository
git clone https://github.com/Muhammedsuwaneh/wpf-generative-ai-app

# Navigate to the project folder
cd wpf-generative-ai-app

# Build and run the project in Visual Studio
```

- Get your OpenAI API KEY/TOKEN from [here](https://platform.openai.com/docs/overview)

- Set your API_KEY. Note: This should only be used in development. For production, consider using safer methods of retrieving your API KEY.

```bash
  private string API_KEY = "YOUR_API_KEY"
```

- Use Visual studio to execute the solution GenAI_ImageGenerator.csproj

⚙️ List all packages/dependencies 

```bash
  Install-Package <PackageName> [-Version <version>] [-ProjectName <project>] [-Source <source>] [-DependencyVersion <dependency>]
```

⚙️ Install a package

```bash
  Install-Package <PackageName> [-Version <version>] [-ProjectName <project>] [-Source <source>] [-DependencyVersion <dependency>]
```

⚙️ Technologies/Dependencies used

<div id="badges">
  <img src="https://img.shields.io/badge/-C Sharp-green" />
  <img src="https://img.shields.io/badge/-dotnet core 8-red" />
  <img src="https://img.shields.io/badge/-WPF-blue" />
  <img src="https://img.shields.io/badge/-Xaml-green" />
  <img src="https://img.shields.io/badge/-OpenAI-red" />
  <img src="https://img.shields.io/badge/-Serilog-brown" />
  <img src="https://img.shields.io/badge/-Microsoft Dependency Injection-green" />
  <img src="https://img.shields.io/badge/-Material Design-blue" />
</div>



🖥️ User Interface


🤖 Main window 

![Screenshot](Screenshots/MainWindow.png)

🤖 Generated Image Dialog

![Screenshot](Screenshots/loading.png)

![Screenshot](Screenshots/dialog.png)


🎙️ Speech to text

![Screenshot](Screenshots/cognitive.png)

## Version 
1.0.0

## Licenced 
Under [`MIT`](LICENSE) - Copyright 2025  

