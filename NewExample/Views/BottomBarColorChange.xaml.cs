
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class BottomBarColorChange : PhoneApplicationPage
    {
        public BottomBarColorChange()
        {
            InitializeComponent();
            this.DataContext = new BottomBarColorChangeViewModel();
        }
    }
}