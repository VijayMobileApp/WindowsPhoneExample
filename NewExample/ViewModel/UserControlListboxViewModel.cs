using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ReactiveUI;
using System.Collections.ObjectModel;
using NewExample.Model;
using ReactiveUI.Xaml;
using System.Xml.Linq;

namespace NewExample.ViewModel
{
    public class UserControlListboxViewModel : ReactiveObject
    {
        public static ObservableCollection<UserControlListboxModel> _StudentDetails;
        public ObservableCollection<UserControlListboxModel> StudentDetails
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


        public int _MemberPrivacy = -1;
        public int MemberPrivacy
        {
            get { return _MemberPrivacy; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.MemberPrivacy, value);               
            }
        }


        public static string _addImage;
        public string addImage
        {
            get { return _addImage; }
            set { this.RaiseAndSetIfChanged(x => x.addImage, value); }
        }
        
       
        //private int selectedIndex;
        //public int SelectedIndex
        //{
        //    get { return selectedIndex; }
        //    set
        //    {
        //        if (selectedIndex == value)
        //            return;
        //        selectedIndex = value;
        //    }
        //}

        //public ListBoxEventsModel _SelectedStudent;
        //public ListBoxEventsModel SelectedStudent
        //{
        //    get { return _SelectedStudent; }
        //    set
        //    {
        //        if (SelectedStudent == value)
        //                        return;
        //        this.RaiseAndSetIfChanged(x => x.SelectedStudent, value);
        //        MessageBox.Show("Selected index==>" + SelectedStudent.FirstName);
        //        _MemberPrivacy = -1;
        //    }
        //}

        private UserControlListboxModel selectedStudent;
        public UserControlListboxModel SelectedStudent
        {
            get { return selectedStudent; }

            set
            {
                if (selectedStudent == value )
                    return;
                selectedStudent = value;
                Console.WriteLine("Selected Name==>" + selectedStudent.FirstName);
            }
        }
      
        public ReactiveAsyncCommand addPerson { get; set; }
        public ReactiveAsyncCommand testingButton { get; set; }
        public ReactiveAsyncCommand EventPageCommand { get; set; }


        XDocument myData = XDocument.Load("Student.xml");

        public UserControlListboxViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<UserControlListboxModel>();
                StudentDetails = UserControlListboxModel.extract(myData.ToString());
                addImage = "/NewExample;component/Images/icon_increase.png";
            });
            getOrgDetails.Execute(true);

            addPerson = new ReactiveAsyncCommand();
            addPerson.Subscribe(x =>
            {
                MessageBox.Show("Test Button Selected..");
                Constants.buttonSelected = false;
            });

        }

    }
}
