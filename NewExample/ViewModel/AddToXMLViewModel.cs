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
using System.Collections.Generic;
using System.Xml.Linq;
using ReactiveUI.Xaml;
using NewExample.Model;
using System.IO.IsolatedStorage;
using System.Collections.ObjectModel;
using System.IO;

namespace NewExample.ViewModel
{
    public class AddToXMLViewModel : ReactiveObject
    {
        public static string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { this.RaiseAndSetIfChanged(x => x.FirstName, value); }
        }

        public static string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { this.RaiseAndSetIfChanged(x => x.LastName, value); }
        }

        public static string _Age;
        public string Age
        {
            get { return _Age; }
            set { this.RaiseAndSetIfChanged(x => x.Age, value); }
        }


        public static ObservableCollection<AddToXML_Model> _StudentDetails;
        public ObservableCollection<AddToXML_Model> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }

        XDocument myData = XDocument.Load("Student.xml");

        public ReactiveAsyncCommand showDetailsBtn { get; set; }
        public ReactiveAsyncCommand AddBtn { get; set; }

        public AddToXMLViewModel()
        {

            showDetailsBtn = new ReactiveAsyncCommand();
            showDetailsBtn.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<AddToXML_Model>();
                StudentDetails=AddToXML_Model.extract(myData.ToString());
            });

            AddBtn = new ReactiveAsyncCommand();
            AddBtn.Subscribe(x =>
            {
                FirstName = "";
                LastName = "";
                Age = "";
                MessageBox.Show("Not working. Have to study in Web..!");
            });
        }
    }
}
