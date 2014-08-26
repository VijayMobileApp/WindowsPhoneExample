using System;
using ReactiveUI;
using NewExample.Model;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using ReactiveUI.Xaml;
namespace NewExample.ViewModel
{
    public class OrderDetailPageViewModel : ReactiveObject
    {
        public static ObservableCollection<OrderDetailModel> _StudentDetails;
        public ObservableCollection<OrderDetailModel> StudentDetails
        {
            get { return _StudentDetails; }
            set { this.RaiseAndSetIfChanged(x => x.StudentDetails, value); }
        }

        public static ObservableCollection<OrderDetailModel> _productDetailList;
        public ObservableCollection<OrderDetailModel> productDetailList
        {
            get { return _productDetailList; }
            set { this.RaiseAndSetIfChanged(x => x.productDetailList, value); }
        }

        public static ObservableCollection<OrderDetailModel> _yourChoiceList;
        public ObservableCollection<OrderDetailModel> yourChoiceList
        {
            get { return _yourChoiceList; }
            set { this.RaiseAndSetIfChanged(x => x.yourChoiceList, value); }
        }

        public static ObservableCollection<OrderDetailModel> _linkList;
        public ObservableCollection<OrderDetailModel> linkList
        {
            get { return _linkList; }
            set { this.RaiseAndSetIfChanged(x => x.linkList, value); }
        }



        public static string _desc;
        public string desc
        {
            get { return _desc; }
            set { this.RaiseAndSetIfChanged(x => x.desc, value); }
        }


        XDocument myData = XDocument.Load("OrderDetail.xml");
        public OrderDetailPageViewModel()
        {
            var getOrgDetails = new ReactiveAsyncCommand();

            getOrgDetails.Subscribe(x =>
            {
                subscribe();

            });
            getOrgDetails.Execute(true);
        }


        void subscribe()
        {
            StudentDetails = new ObservableCollection<OrderDetailModel>();
            StudentDetails = OrderDetailModel.extract(myData.ToString());
            yourChoiceList = OrderDetailModel.yourChoiceList;
            productDetailList = OrderDetailModel.productDetail;
            linkList = OrderDetailModel.linkList;
            desc = StudentDetails[0].desc;
        }
    }
}
