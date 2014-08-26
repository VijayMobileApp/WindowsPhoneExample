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

namespace NewExample.Views
{
    public partial class GetPagesFromPageStack : PhoneApplicationPage
    {
        public GetPagesFromPageStack()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                if (frame.CanGoBack)
                {
                    string pageUri = string.Empty;
                    foreach (var item in frame.BackStack)
                    {
                        pageUri = item.Source.ToString();
                        Console.WriteLine("Page URI==> "+pageUri);
                        //if (pageUri == "/com/beno/WP7Client/views/CreditCardPayment.xaml" || pageUri == "/com/beno/WP7Client/views/PaymentType.xaml")
                            
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}