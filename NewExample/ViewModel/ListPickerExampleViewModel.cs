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
using NewExample.Model;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace NewExample.ViewModel
{
    public class ListPickerExampleViewModel : ReactiveObject
    {
        public static ObservableCollection<ListPickerExampleModel> _feedName;
        public ObservableCollection<ListPickerExampleModel> feedName
        {
            get { return _feedName; }
            set { this.RaiseAndSetIfChanged(x => x.feedName, value); }
        }

        public int _MemberPrivacy=-1;
        public int MemberPrivacy
        {
            get { return _MemberPrivacy; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.MemberPrivacy, value);
                MessageBox.Show("Selected Index==>" + (MemberPrivacy));
            }
        }


        string[] items = { " Item 1", "Item 2", "Item 3", "Item 4", "Item 5"," Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };

        public ListPickerExampleViewModel()
        {
            DateTime.Now.AddDays(7).ToString("dd/MM/yy");
            DateTime.Now.AddMonths(-1);

            ListPickerExampleModel mod = new ListPickerExampleModel();
            feedName = new ObservableCollection<ListPickerExampleModel>();
            for (int i = 0; i < items.Length; i++)
            {
                mod.feetTypes = items[i];
                feedName.Add(mod);
                mod = new ListPickerExampleModel();
            }
        }
    }
}
