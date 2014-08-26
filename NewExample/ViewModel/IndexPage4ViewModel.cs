

using System;
using ReactiveUI.Xaml;
namespace NewExample.ViewModel
{
    public class IndexPage4ViewModel
    {
        public ReactiveAsyncCommand imageExampleButton { get; set; }
        public ReactiveAsyncCommand facebookButton { get; set; }
        

        public IndexPage4ViewModel()
        {
            imageExampleButton = new ReactiveAsyncCommand();
            imageExampleButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ImageSelectionExample.xaml", UriKind.Relative));
            });

            facebookButton = new ReactiveAsyncCommand();
            facebookButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/FacebookLoginPage.xaml", UriKind.Relative));
            });


        }
    }
}
