using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace GenAI_ImageGenerator.Commands.Events
{
    public class EventArgsCommandAction : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(EventArgsCommandAction), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            if (Command != null && Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }
    }
}
