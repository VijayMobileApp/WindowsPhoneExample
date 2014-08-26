
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class ImageListBox : PhoneApplicationPage
    {
        public ImageListBox()
        {
            InitializeComponent();
            this.DataContext = new ImageListBoxViewModel();
        }
    }
}