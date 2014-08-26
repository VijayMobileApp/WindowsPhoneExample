
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using NewExample.Model;
using System.Xml.Linq;
using ReactiveUI.Xaml;
using NewExample.WindowsPhone7Unleashed;
using System.Threading;
using System.Windows;
using System.Windows.Input;
namespace NewExample.ViewModel
{
    public class IncrementScrollerViewModel : INotifyPropertyChanged
    { private static ObservableCollection<IncrementScrollerModel> listForLoading = new ObservableCollection<IncrementScrollerModel>();

        private static ObservableCollection<IncrementScrollerModel> _StudentDetails;
        public ObservableCollection<IncrementScrollerModel> StudentDetails
        {
            get { return _StudentDetails; }
            set
            {
                if (_StudentDetails == value)
                    return;
                _StudentDetails = value;
            }
        }

        int total = 0;
        int end = 10;
        int start = 0;


        int taken = 0;  // number of items already taken
        int totalToTake = 0;


        IncrementScrollerModel test = new IncrementScrollerModel();
        XDocument myData = XDocument.Load("Student.xml");

        public IncrementScrollerViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                StudentDetails = new ObservableCollection<IncrementScrollerModel>();
                listForLoading = StudentDetails = IncrementScrollerModel.extract(myData.ToString());
                total = listForLoading.Count;
                totalToTake = listForLoading.Count;
            });
            getOrgDetails.Execute(true);

            AddMoreItems();

            fetchMoreDataCommand = new DelegateCommand(
                obj =>
                {
                    if (busy)
                    {
                        return;
                    }
                    Busy = true;
                    ThreadPool.QueueUserWorkItem(
                        delegate
                        {
                            /* This is just to demonstrate a slow operation. */
                            Thread.Sleep(3000);
                            /* We invoke back to the UI thread. 
                             * Ordinarily this would be done 
                             * by the Calcium infrastructure automatically. */
                            Deployment.Current.Dispatcher.BeginInvoke(
                                delegate
                                {
                                    AddMoreItems();
                                    Busy = false;
                                });
                        });

                });
        }


        void AddMoreItems()
        {
            if (taken >= totalToTake) return;  // all taken

            int i = 0;
            int stopi = taken + 10;
            foreach (var item in StudentDetails)
            {
                if (i >= taken && i < stopi)
                {
                    items.Add(new IncrementScrollerModel() { FirstName = item.FirstName, LastName = item.LastName, Age = item.Age, PersonImage = item.PersonImage });
                    taken++;
                }
                ++i;
            }
        }

        //void AddMoreItems()
        //{
        //    if (total > 0)
        //    {
        //        //for (int i = start; i < end; i++)
        //        //{
        //        //    items.Add("Item " + i);
        //        //    //items.Add(new IncrementScrollerModel() { FirstName = StudentDetails.});
        //        //    //LastName
        //        //    //Age
        //        //    //PersonImage
        //        //}

        //        int i = start;
        //        foreach (var item in StudentDetails)
        //        {
        //            if (i < end)
        //            {
        //                //test.FirstName = item.FirstName;
        //                //test.LastName = item.LastName;
        //                //test.Age = item.Age;
        //                //test.PersonImage = item.PersonImage;
        //                items.Add(new IncrementScrollerModel() { FirstName = item.FirstName,LastName = item.LastName,Age = item.Age,PersonImage=item.PersonImage });
        //                ////items.Add(new IncrementScrollerModel() { FirstName = item.FirstName });
        //                ////items.Add(new IncrementScrollerModel() { LastName = item.LastName });
        //                ////items.Add(new IncrementScrollerModel() { Age = item.Age });
        //                ////items.Add(new IncrementScrollerModel() { PersonImage = item.PersonImage });
        //                //items.Add(test);
        //                //StudentDetails.RemoveAt(i);
        //                //StudentDetails.Insert(i, null);
        //                //test = new IncrementScrollerModel();
        //                i++;
        //            }
        //        }
        //        total = total > 10 ? total - 10 : total - total;
        //        start = items.Count;
        //        end = total > 10 ? start + 10 : start + total;
        //    }


        //for (int i = start; i < end; i++)
        //{
        //    //items.Add("Item " + i);
        //    items.Add(new IncrementScrollerModel() { FirstName = StudentDetails.});
        //    //LastName
        //    //Age
        //    //PersonImage
        //}


        //}

        //void AddMoreItems()
        //{
        //    int start = items.Count;
        //    int end = start + 10;
        //    for (int i = start; i < end; i++)
        //    {
        //        items.Add("Item " + i);
        //    }
        //}

        readonly DelegateCommand fetchMoreDataCommand;

        public ICommand FetchMoreDataCommand
        {
            get
            {
                return fetchMoreDataCommand;
            }
        }

        readonly ObservableCollection<IncrementScrollerModel> items = new ObservableCollection<IncrementScrollerModel>();

        public ObservableCollection<IncrementScrollerModel> Items
        {
            get
            {
                return items;
            }
        }


        //readonly ObservableCollection<string> items = new ObservableCollection<string>();

        //public ObservableCollection<string> Items
        //{
        //    get
        //    {
        //        return items;
        //    }
        //}

        bool busy;

        public bool Busy
        {
            get
            {
                return busy;
            }
            set
            {
                if (busy == value)
                {
                    return;
                }
                busy = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Busy"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var tempEvent = PropertyChanged;
            if (tempEvent != null)
            {
                tempEvent(this, e);
            }
        }
    }

    /*
      void AddMoreItems()
            {
                if (total > 0)
                {
                    for (int i = start; i < end; i++)
                    {
                        items.Add("Item " + i);
                    }
                }

                if (total > 10)
                {
                    listTotal = total - 10;
                    total = total - 10;
                }
                else
                {
                    listTotal = total;
                    total = total - total;
                }

                start = items.Count;

                if (listTotal > 10)
                    end = start + 10;
                else
                    end = start + listTotal;


           
            }
        */


    /*
      void AddMoreItems()
        {
            if (total > 0)
                for (int i = start; i < end; i++)
                {
                    //items.Add("Item " + i);
                    items.Add(new IncrementScrollerModel() { FirstName = StudentDetails.});
                    //LastName
                    //Age
                    //PersonImage
                }

            total = total > 10 ? total - 10 : total - total;

            start = items.Count;

            end = total > 10 ? start + 10 : start + total;
        } 
     */

}
