
using NewExample.ViewModel;
using System.Windows.Controls;

namespace NewExample
{
    public partial class SlidingMenu : UserControl
    {
        public SlidingMenu()
        {
            InitializeComponent();
            this.DataContext = new SlidingMenuViewModel();
        }
    }
}
