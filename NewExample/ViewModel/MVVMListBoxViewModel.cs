using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using ReactiveUI.Xaml;
using System.Xml.Linq;
using NewExample.Model;
using System.Windows;
using System.Windows.Controls;
using NewExample.Views;
using GalaSoft.MvvmLight.Command;


namespace NewExample.ViewModel
{
    public class MVVMListBoxViewModel : ReactiveObject
    {
        public static ObservableCollection<MVVMListBoxModel> _StudentDetails;
        public ObservableCollection<MVVMListBoxModel> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }

        public static string _imagePath;
        public string imagePath
        {
            get { return _imagePath; }
            set { this.RaiseAndSetIfChanged(x => x.imagePath, value); }
        }

        public static int _SelectedIndex = -1;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.SelectedIndex, value);               
            }
        }

       

        //private MVVMListBoxModel selectedStudent;
        //public MVVMListBoxModel SelectedStudent
        //{          
        //    get { return selectedStudent; }

        //    set
        //    {
        //        MessageBox.Show("SelectedIndex==>" + SelectedIndex);
        //        if (selectedStudent == value)
        //            return;
        //        selectedStudent = value;
        //        MessageBox.Show("Selected Item==>" + selectedStudent.FirstName);
        //        _SelectedIndex = -1;
                
        //        //if (SelectedIndex == 0)
        //        //{
        //        //    var rootFrame = (App.Current as App).RootFrame;
        //        //    rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        //        //}
        //        // Do logic on selection change.
        //    }
        //}

        public RelayCommand<MVVMListBoxModel> ItemSelectedCommand { get; private set; }

        public ReactiveAsyncCommand EventPageCommand { get; set; }
        public ReactiveAsyncCommand addPerson { get; set; }




        XDocument myData = XDocument.Load("Student.xml");

        public MVVMListBoxViewModel()
        {
          
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<MVVMListBoxModel>();
                StudentDetails = MVVMListBoxModel.extract(myData.ToString());
                imagePath = "/NewExample;component/Images/icon_increase.png";
            });
            getOrgDetails.Execute(true);

            //addPerson = new ReactiveAsyncCommand();
            //addPerson.Subscribe(x =>
            //{
            //    MessageBox.Show("Button Clicked..!!");
            //});

            ItemSelectedCommand = new RelayCommand<MVVMListBoxModel>(ItemSelected);

            //EventPageCommand = new ReactiveAsyncCommand();
            //EventPageCommand.Subscribe(x =>
            //{
            //    MessageBox.Show("List box item is clicked.");
            //    // ListBox listbox = (ListBox)sender;
            //    //ListBoxEventsModel items = (ListBoxEventsModel)listbox.SelectedItem;
            //    //MessageBox.Show("Selected Name" + items.ToString());

            //    var myUser = ListBoxEventsModel;// ((ListBox)this).DataContext as ListBoxEventsModel;
            //    MessageBox.Show("Selected==>" + myUser.FirstName);
            //});
        }
        
        private void ItemSelected(MVVMListBoxModel myItem)
        {
            if (null!=myItem)
            MessageBox.Show("Name==>" + myItem.FirstName);
            //throw new NotImplementedException();
        }
    }
}


