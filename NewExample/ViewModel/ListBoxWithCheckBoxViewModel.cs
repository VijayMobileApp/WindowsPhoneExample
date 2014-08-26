using System;
using ReactiveUI;
using System.Collections.ObjectModel;
using NewExample.Model;
using System.Xml.Linq;
using ReactiveUI.Xaml;
using System.Windows;
using GalaSoft.MvvmLight.Command;
namespace NewExample.ViewModel
{
    public class ListBoxWithCheckBoxViewModel : ReactiveObject
    {
        public static ObservableCollection<ListBoxWithCheckBoxModel> _StudentDetails;
        public ObservableCollection<ListBoxWithCheckBoxModel> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }

        public static ListBoxWithCheckBoxModel _SelectedItem;
        public ListBoxWithCheckBoxModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.SelectedItem, value);
                MessageBox.Show(SelectedItem.FirstName);
            }
        }

        public bool _isChecked;
        public bool isChecked
        {
            get { return _isChecked; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.isChecked, value);
                MessageBox.Show("==> "+isChecked);
            }
        }

         XDocument myData = XDocument.Load("Student.xml");

         public RelayCommand<ListBoxWithCheckBoxModel> ItemSelectedCommand { get; private set; }

        public ListBoxWithCheckBoxViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<ListBoxWithCheckBoxModel>();
                StudentDetails = ListBoxWithCheckBoxModel.extract(myData.ToString());

            });
            getOrgDetails.Execute(true);

            ItemSelectedCommand = new RelayCommand<ListBoxWithCheckBoxModel>(ItemSelected);

        }

        private void ItemSelected(ListBoxWithCheckBoxModel myItem)
        {
            if (null != myItem)
            {
                RedirectPageViewModel.selectedValue = myItem;
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/RedirectPage.xaml", UriKind.Relative));
            }
        }
    }
}
