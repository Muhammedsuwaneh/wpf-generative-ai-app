using GenAI_ImageGenerator.Extensions;
using GenAI_ImageGenerator.Services;
using GenAI_ImageGenerator.ViewModels;
using GenAI_ImageGenerator.Views.Templates.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GenAI_ImageGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();

                // view models
                services.RegisterService<MainViewModel>();
                services.RegisterService<ImageDialogViewModel>();

                // views 
                services.RegisterService<ImageDialog>();

                // services 

            }).Build();
        }

        protected async override void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var mainWindow = AppHost!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }

}
