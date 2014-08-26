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
using ReactiveUI;
using ReactiveUI.Xaml;
using Microsoft.Phone.Controls;

namespace NewExample.ViewModel
{
    public class WebBrowserExampleViewModel : ReactiveObject
    {
        public static string _webSource;
        public string webSource
        {
            get { return _webSource; }
            set { this.RaiseAndSetIfChanged(x => x.webSource, value); }
        }

        public static string _source;
        public string source
        {
            get { return _source; }
            set { this.RaiseAndSetIfChanged(x => x.source, value); }
        }

        public Visibility _progressVisiblity = Visibility.Collapsed;
        public Visibility progressVisiblity
        {
            get { return _progressVisiblity; }
            set { this.RaiseAndSetIfChanged(x => x.progressVisiblity, value); }
        }

        public ReactiveAsyncCommand goButton { get; set; }
        public ReactiveAsyncCommand BrowserNavigated { get; set; }

        public WebBrowserExampleViewModel()
        {
            goButton = new ReactiveAsyncCommand();
            goButton.Subscribe(x =>
            {
                if (!String.IsNullOrEmpty(source))
                {
                    string html = String.Format("<html><head></head><body><img style='width:100%' src='{0}'/></body></html>", source);
                    Console.WriteLine("html==> " + html);
                    progressVisiblity = Visibility.Visible;
                    //webSource = "https://" + source;//"https://www.facebook.com/Burger.King.Turkiye";
                    //webSource = html;
                    webSource = source;
                }
            });
        }

    }
}
