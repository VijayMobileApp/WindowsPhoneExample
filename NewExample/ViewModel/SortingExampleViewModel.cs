using System;
using ReactiveUI;
using System.Linq;
using System.Collections.ObjectModel;
using ReactiveUI.Xaml;
using System.Collections.Generic;

namespace NewExample.ViewModel
{
    public class SortingExampleViewModel : ReactiveObject
    {
        public string _SearchText = "";
        public string SearchText
        {
            get { return _SearchText; }
            set { this.RaiseAndSetIfChanged(x => x.SearchText, value); }
        }

        public static ObservableCollection<items> _sordtedList;
        public ObservableCollection<items> sordtedList
        {
            get { return _sordtedList; }
            set { this.RaiseAndSetIfChanged(x => x.sordtedList, value); }
        }

        public static ObservableCollection<items> _tempSordtedList;
        public ObservableCollection<items> tempSordtedList
        {
            get { return _tempSordtedList; }
            set { this.RaiseAndSetIfChanged(x => x.tempSordtedList, value); }
        }


        public ReactiveAsyncCommand ExecuteSearch { get; set; }

        public SortingExampleViewModel()
        {
            ObservableCollection<items> myData = new ObservableCollection<items>()
            {
                //new items(){firstName = "Vijay",age=27},
                //new items(){firstName = "Vijay",age=28},
                //new items(){firstName = "Vijay",age=29},
                //new items(){firstName = "Vijay",age=30},
                //new items(){firstName = "Vijay",age=31},
                //new items(){firstName = "Vijay",age=32}

                new items(){firstName = "Vijay Dhas",age=27},
                new items(){firstName = "Ramaraj",age=28},
                new items(){firstName = "Arun",age=29},
                new items(){firstName = "Prabhu",age=30},
                new items(){firstName = "Pranesh",age=31},
                new items(){firstName = "Testing",age=32}
            };

            ////Ascending Order
            sordtedList = new ObservableCollection<items>(from i in myData orderby i.firstName select i);
            ////Descending Order
            //sordtedList = new ObservableCollection<items>(from i in myData orderby i.firstName descending select i);

            var canConfirm = this.WhenAny(x => x.SearchText, (search) => SearchMethod(search.Value));
            ExecuteSearch = new ReactiveAsyncCommand(canConfirm, 0);
        }

        public Boolean SearchMethod(String searchValue)
        {
            var col = (ObservableCollection<items>)(sordtedList.Select(p => p.firstName = searchValue));
            foreach (items objTest in col)
            {
                tempSordtedList.Add(objTest);
            }
            sordtedList = tempSordtedList;
            return true;
        }


        protected void Page_Load(object sender, EventArgs e)
        {


        }

    }

    public class items
    {
        public string firstName { get; set; }
        public int age { get; set; }
    }
}
