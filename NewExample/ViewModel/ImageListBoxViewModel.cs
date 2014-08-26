using System;
using ReactiveUI;
using System.Collections.ObjectModel;
using NewExample.Model;
using ReactiveUI.Xaml;
using GalaSoft.MvvmLight.Command;
using System.Windows;
namespace NewExample.ViewModel
{
    public class ImageListBoxViewModel : ReactiveObject
    {
        ImageListBoxModel lgp = new ImageListBoxModel();
        ObservableCollection<ImageListBoxModel> content = new ObservableCollection<ImageListBoxModel>();

        public static ObservableCollection<ImageListBoxModel> _listImages;
        public ObservableCollection<ImageListBoxModel> listImages
        {
            get { return _listImages; }
            set { this.RaiseAndSetIfChanged(x => x.listImages, value); }
        }

        public static int _selectedIndex=0;
        public int selectedIndex
        {
            get { return _selectedIndex; }
            set { this.RaiseAndSetIfChanged(x => x.selectedIndex, value); }
        }

        public RelayCommand<ImageListBoxModel> ItemSelectedCommand { get; private set; }

        public ImageListBoxViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                listImages = new ObservableCollection<ImageListBoxModel>();
                //listImages = ImageListBoxModel.extract(selectedIndex);
                listImages = imageLoad(selectedIndex);
            });
            getOrgDetails.Execute(true);

            ItemSelectedCommand = new RelayCommand<ImageListBoxModel>(ItemSelected);
        }

        private void ItemSelected(ImageListBoxModel myItem)
        {
            if (null != myItem)
            {
                listImages = new ObservableCollection<ImageListBoxModel>();
                //listImages = ImageListBoxModel.extract(myItem.index);
                listImages = imageLoad(myItem.index);
            }
        }

        private ObservableCollection<ImageListBoxModel> imageLoad(int selectedCategory)
        {
            content = new ObservableCollection<ImageListBoxModel>();
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
