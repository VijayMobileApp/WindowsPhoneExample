using System;
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class ImageSelectionExample : PhoneApplicationPage
    {
        public ImageSelectionExample()
        {
            InitializeComponent();
            this.DataContext = new ImageSelectionExampleViewModel();
        }
    }
}