🤖 WPF Generative AI Desktop Application

## About application

The application generates AI Images from user prompts using OpenAI's Dall-E-3 model.
The application also supports a speech-to-text cognitive service using System.Speech.Recognition library.

## Prerequisites / how to run

- Get your OpenAI API KEY/TOKEN from [here](https://platform.openai.com/docs/overview)

- Set your API_KEY. Note: This should only be used in development. For production, consider using safer methods of retrieving your API KEY.

```bash
  private string API_KEY = "YOUR_API_KEY"
```

- Use Visual studio to execute the solution GenAI_ImageGenerator.csproj

### List all packages/dependencies 

```bash
  Install-Package <PackageName> [-Version <version>] [-ProjectName <project>] [-Source <source>] [-DependencyVersion <dependency>]
```

## Install a package

```bash
  Install-Package <PackageName> [-Version <version>] [-ProjectName <project>] [-Source <source>] [-DependencyVersion <dependency>]
```

## Technologies/Dependencies used

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

## User Interface

### Main window 
![Screenshot](Screenshots/MainWindow.png)

### Generated Image Dialog

![Screenshot](Screenshots/dialog.png)

### Speech to text

![Screenshot](Screenshots/cognitive.png)

![Screenshot](Screenshots/loading.png)

## Version 
1.0.0

## Licenced 
Under [`MIT`](LICENSE) - Copyright 2025  

