
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class AppVersionCheck : PhoneApplicationPage
    {
        public AppVersionCheck()
        {
            InitializeComponent();
            this.DataContext = new AppVersionCheckViewModel();
        }
    }
}