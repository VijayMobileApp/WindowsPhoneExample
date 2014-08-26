
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class RedirectPage : PhoneApplicationPage
    {
        public RedirectPage()
        {
            InitializeComponent();
            DataContext = new RedirectPageViewModel();
        }
    }
}