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
    public partial class ReceiveDataFromAnotherPage : PhoneApplicationPage
    {
        public string val;

        public ReceiveDataFromAnotherPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            //2nd way to receive the value from one page
            NavigationContext.QueryString.TryGetValue("passingValue", out val);
            MessageBox.Show(val);
            ReceiveFromAnotherPageUIContainer.DataContext = new ReceiveDataFromAnotherPageViewModel(val);
        }
    }
}