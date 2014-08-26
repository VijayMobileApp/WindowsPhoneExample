
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class DateFormatExample : PhoneApplicationPage
    {
        public DateFormatExample()
        {
            InitializeComponent();
            this.DataContext = new DateFormatExampleViewModel();
        }
    }
}