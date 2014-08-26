
using System.Collections.ObjectModel;
namespace NewExample.Model
{
    public class ImageListBoxModel
    {
        public string images { get; set; }
        public int index { get; set; }

        public static ObservableCollection<ImageListBoxModel> extract(int selectedCategory)
        {
            ImageListBoxModel lgp = new ImageListBoxModel();
            ObservableCollection<ImageListBoxModel> content = new ObservableCollection<ImageListBoxModel>();


            for (int i = 0; i < 13; i++)
            {
                if (selectedCategory == i)
                {
                    lgp.images = "/NewExample;component/Images/icon_slider_" + i + "_default.png";
                    lgp.index = i;
                }
                else
                {
                    lgp.images = "/NewExample;component/Images/icon_slider_" + i + "_selected.png";
                    lgp.index = i;
                   
                }
                content.Add(lgp);
                lgp = new ImageListBoxModel();
            }
            return content;
        }
    }
}
