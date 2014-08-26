using ReactiveUI;
using ReactiveUI.Xaml;
using System.Windows.Media;
using System;
using System.Windows.Navigation;

namespace NewExample.ViewModel
{

    public class BottomBarColorChangeViewModel : ReactiveObject
    {
        public ReactiveAsyncCommand tabButton1 { get; set; }
        public ReactiveAsyncCommand tabButton2 { get; set; }
        public ReactiveAsyncCommand tabButton3 { get; set; }
        public ReactiveAsyncCommand tabButton4 { get; set; }
        public BottomBarColorChangeViewModel()
        {
            tabButton1 = new ReactiveAsyncCommand();
            tabButton1.Subscribe(x =>
            {
                BottomTabBarViewModel._BackColor1 = new SolidColorBrush(Colors.Gray);
                BottomTabBarViewModel._BackColor2 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor3 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor4 = new SolidColorBrush(Colors.Black);

                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            });

            tabButton2 = new ReactiveAsyncCommand();
            tabButton2.Subscribe(x =>
            {
                BottomTabBarViewModel._BackColor2 = new SolidColorBrush(Colors.Gray);
                BottomTabBarViewModel._BackColor1 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor3 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor4 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage2.xaml", UriKind.Relative));
            });

            tabButton3 = new ReactiveAsyncCommand();
            tabButton3.Subscribe(x =>
            {
                BottomTabBarViewModel._BackColor3 = new SolidColorBrush(Colors.Gray);
                BottomTabBarViewModel._BackColor2 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor1 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor4 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage3.xaml", UriKind.Relative));

            });

            tabButton4 = new ReactiveAsyncCommand();
            tabButton4.Subscribe(x =>
            {
                BottomTabBarViewModel._BackColor4 = new SolidColorBrush(Colors.Gray);
                BottomTabBarViewModel._BackColor2 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor3 = new SolidColorBrush(Colors.Black);
                BottomTabBarViewModel._BackColor1 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage4.xaml", UriKind.Relative));
            });
        }

    }
}
