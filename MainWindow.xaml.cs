using GenAI_ImageGenerator.Factory.Interfaces;
using GenAI_ImageGenerator.ViewModels;
using System.Windows;

namespace GenAI_ImageGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IAbstractFactory<MainViewModel> factory)
        {
            InitializeComponent();
            DataContext = factory.Create();
        }
    }
}