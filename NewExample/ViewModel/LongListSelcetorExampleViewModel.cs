using System;
using ReactiveUI;
using System.Collections.ObjectModel;
using NewExample.Model;
using System.Windows;
using System.Xml.Linq;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using ReactiveUI.Xaml;
using NewExample.ForLLS;

namespace NewExample.ViewModel
{
    public class LongListSelcetorExampleViewModel : ReactiveObject
    {
        public ObservableCollection<AlphaKeyGroup<LongListSelcetorExampleModel>> _campaignResult;
        public ObservableCollection<AlphaKeyGroup<LongListSelcetorExampleModel>> campaignResult
        {
            get { return _campaignResult; }
            set { this.RaiseAndSetIfChanged(x => x.campaignResult, value); }
        }

        public static ObservableCollection<GroupingLayer<string, LongListSelcetorExampleModel>> _campaign;
        public ObservableCollection<GroupingLayer<string, LongListSelcetorExampleModel>> campaign
        {
            get { return _campaign; }
            set { this.RaiseAndSetIfChanged(x => x.campaign, value); }
        }

        public static string _imagePath;
        public string imagePath
        {
            get { return _imagePath; }
            set { this.RaiseAndSetIfChanged(x => x.imagePath, value); }
        }

        public static LongListSelcetorExampleModel _SelectedItem;
        public LongListSelcetorExampleModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.SelectedItem, value);
                MessageBox.Show(SelectedItem.FirstName);
            }
        }

        XDocument myData = XDocument.Load("Student.xml");

        public RelayCommand<LongListSelcetorExampleModel> ItemSelectedCommand { get; private set; }

        public LongListSelcetorExampleViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                subscribe();

            });
            getOrgDetails.Execute(true);
            ItemSelectedCommand = new RelayCommand<LongListSelcetorExampleModel>(ItemSelected);
        }

        private void ItemSelected(LongListSelcetorExampleModel myItem)
        {
            if (null != myItem)
            {
                MessageBox.Show("FirstName==> " + myItem.FirstName);
            }
        }

        void subscribe()
        {
            ObservableCollection<LongListSelcetorExampleModel> result = LongListSelcetorExampleModel.extract(myData.ToString());

            //campaignResult = new ObservableCollection<AlphaKeyGroup<LongListSelcetorExampleModel>>();
            //campaignResult.Clear();
            //ObservableCollection<AlphaKeyGroup<LongListSelcetorExampleModel>> DataSource = AlphaKeyGroup<LongListSelcetorExampleModel>.CreateGroups(result,
            //       System.Threading.Thread.CurrentThread.CurrentUICulture,
            //       (LongListSelcetorExampleModel s) => { return s.date; },
            //       true);
            //campaignResult = DataSource;

            var selected = from c in result group c by c.date into n select new GroupingLayer<string, LongListSelcetorExampleModel>(n);
            campaign = new ObservableCollection<GroupingLayer<string, LongListSelcetorExampleModel>>(selected);
        }
    }
}
