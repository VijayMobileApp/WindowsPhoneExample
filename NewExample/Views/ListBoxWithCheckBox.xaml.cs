
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class ListBoxWithCheckBox : PhoneApplicationPage
    {
        public ListBoxWithCheckBox()
        {
            InitializeComponent();
            DataContext = new ListBoxWithCheckBoxViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            DataContext = new ListBoxWithCheckBoxViewModel();
        }
    }
}