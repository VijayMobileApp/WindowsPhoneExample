
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class IndexPage4 : PhoneApplicationPage
    {
        public IndexPage4()
        {
            InitializeComponent();
            this.DataContext = new IndexPage4ViewModel();
        }
    }
}