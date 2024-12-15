using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UwpExample.Abstractions;

namespace UwpExample.Services
{
    public class DialogService : IDialogService
    {
        private readonly ContentDialog _contentDialog;

        public DialogService(CustomContentDialog contentDialog)
        {
            _contentDialog = contentDialog;
        }
        
        public async Task ShowDialogAsync(string message)
        {
            _contentDialog.Content = message;
            var customButton = new Style(typeof(Button));
            customButton.Setters.Add(new Setter(Control.BackgroundProperty, "#05717f"));
            customButton.Setters.Add(new Setter(Control.ForegroundProperty, Colors.White));
            _contentDialog.PrimaryButtonStyle = customButton;
            await _contentDialog.ShowAsync();
        }
    }
}