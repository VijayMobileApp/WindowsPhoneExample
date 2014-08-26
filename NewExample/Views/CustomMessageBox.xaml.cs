
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class CustomMessageBox : PhoneApplicationPage
    {
        public CustomMessageBox()
        {
            InitializeComponent();
            this.DataContext = new CustomMessageBoxViewModel();
        }
    }
}