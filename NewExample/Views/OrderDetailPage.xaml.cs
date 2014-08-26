
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class OrderDetailPage : PhoneApplicationPage
    {
        public OrderDetailPage()
        {
            InitializeComponent();
            this.DataContext = new OrderDetailPageViewModel();
        }
    }
}