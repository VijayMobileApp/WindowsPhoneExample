using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class WebBrowserExample : PhoneApplicationPage
    {
        public WebBrowserExample()
        {
            InitializeComponent();
            WebBrowserUIContainer.DataContext = new WebBrowserExampleViewModel();
        }

        private void MiniBrowser_Navigating(object sender, NavigatingEventArgs e)
        {
            ProgressGrid.Visibility = Visibility.Visible;
        }

        private void MiniBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            ProgressGrid.Visibility = Visibility.Collapsed;
        }

        private void MiniBrowser_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            ProgressGrid.Visibility = Visibility.Collapsed;
        }

        private void MiniBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            ProgressGrid.Visibility = Visibility.Collapsed;
        }
    }
}