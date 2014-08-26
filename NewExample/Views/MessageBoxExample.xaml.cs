
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class MessageBoxExample : PhoneApplicationPage
    {
        public MessageBoxExample()
        {
            InitializeComponent();
            this.DataContext = new MessageBoxExampleViewModel();
        }
    }
}