using System;
using NewExample.Model;
using ReactiveUI;
using ReactiveUI.Xaml;
using System.Windows.Media;

namespace NewExample.ViewModel
{
    public class RedirectPageViewModel : ReactiveObject
    {
        public static ListBoxWithCheckBoxModel selectedValue { get; set; }

        public static string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { this.RaiseAndSetIfChanged(x => x.FirstName, value); }
        }
        public static string _LastyName;
        public string LastyName
        {
            get { return _LastyName; }
            set { this.RaiseAndSetIfChanged(x => x.LastyName, value); }
        }


        public ReactiveAsyncCommand goToNextPage { get; set; }

        public RedirectPageViewModel()
        {
            if(!string.IsNullOrEmpty(selectedValue.FirstName))
            {
                FirstName = selectedValue.FirstName;
                LastyName = selectedValue.LastName;
            }
           
            goToNextPage = new ReactiveAsyncCommand();
            goToNextPage.Subscribe(x => {
                BottomTabBarViewModel._BackColor2 = new SolidColorBrush(Colors.Gray);
                BottomTabBarViewModel._BackColor1 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor3 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor4 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage2.xaml", UriKind.Relative));
            });
        }
    }
}
