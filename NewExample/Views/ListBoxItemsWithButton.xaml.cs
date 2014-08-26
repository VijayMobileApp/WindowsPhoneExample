
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class ListBoxItemsWithButton : PhoneApplicationPage
    {
        public ListBoxItemsWithButton()
        {
            InitializeComponent();
            this.DataContext = new ListBoxItemsWithButtonViewModel();
        }
    }
}