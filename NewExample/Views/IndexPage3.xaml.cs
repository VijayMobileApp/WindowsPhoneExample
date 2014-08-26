
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class IndexPage3 : PhoneApplicationPage
    {
        public IndexPage3()
        {
            InitializeComponent();
            this.DataContext = new IndexPage3ViewModel();
        }
    }
}