
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class ListBoxToChangeSelectedRow : PhoneApplicationPage
    {
        public ListBoxToChangeSelectedRow()
        {
            InitializeComponent();
            this.DataContext = new ListBoxToChangeSelectedRowViewModel();
        }
    }
}