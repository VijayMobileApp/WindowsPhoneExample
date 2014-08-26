using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using ReactiveUI.Xaml;

namespace NewExample.ViewModel
{
    public class LoadTheSamePageViewModel
    {

        public ReactiveAsyncCommand loadButton { get; set; }
        public LoadTheSamePageViewModel()
        {
            MessageBox.Show("Welcome to Load the same page");
            loadButton = new ReactiveAsyncCommand();
            loadButton.Subscribe(x=>{
            var rootFrame = (App.Current as App).RootFrame;
            rootFrame.Navigate(new Uri(String.Format("/Views/LoadTheSamePage.xaml?id={0}", Guid.NewGuid().ToString()), UriKind.Relative));
            //rootFrame.Navigate(new Uri("/Views/LoadTheSamePage.xaml", UriKind.Relative));
            });
        }

    }
}
