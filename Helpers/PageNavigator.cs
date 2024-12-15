using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpExample.Helpers
{
    public class PageNavigator
    {
        private static readonly Lazy<PageNavigator> _instance =
            new Lazy<PageNavigator>(() => new PageNavigator());

        private PageNavigator()
        {
        }

        public static PageNavigator Instance => _instance.Value;

        public void Navigate(Type sourcePage)
        {
            var frame = (Frame) Window.Current.Content;
            frame.Navigate(sourcePage);
        }

        public void Navigate(Type sourcePage, object parameter)
        {
            var frame = (Frame) Window.Current.Content;
            frame.Navigate(sourcePage, parameter);
        }

        public void GoBack()
        {
            var frame = (Frame) Window.Current.Content;
            frame.GoBack();
        }
    }
}