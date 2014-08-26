
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class LongListSelcetorExample : PhoneApplicationPage
    {
        public LongListSelcetorExample()
        {
            InitializeComponent();
            this.DataContext = new LongListSelcetorExampleViewModel();
        }
    }
}