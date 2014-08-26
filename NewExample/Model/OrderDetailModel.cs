using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;
using NewExample.ModelClass;
using System;
using System.Windows;

namespace NewExample.Model
{
    public class OrderDetailModel
    {
        public string featureMandatory { get; set; }
        public string featureID { get; set; }
        public int featureType { get; set; }
        public string listClickButton { get; set; }

        public Visibility valueVisible { get; set; }
        public Visibility imageVisible { get; set; }
        public Visibility tongleVisible { get; set; }
        public string title { get; set; }
        public string valueDesc { get; set; }
        public bool isCheck { get; set; }

        public string link { get; set; }
        public string url { get; set; }

     
        public string desc { get; set; }
        
        public string defaultImage { get; set; }
        public string thumpnail { get; set; }
        public string productName { get; set; }
        public string productBrandName { get; set; }
        public string productId { get; set; }
        public string listRate { get; set; }
        public string rate { get; set; }
        public string star1 { get; set; }
        public string star2 { get; set; }
        public string star3 { get; set; }
        public string star4 { get; set; }
        public string star5 { get; set; }
        public string ratingString { get; set; }

        //public string serviceName { get; set; }
        //public string serviceId { get; set; }
        //public string serviceFormId { get; set; }
        //public string serviceThumbnail { get; set; }
        //public string serviceLink { get; set; }

        public static ObservableCollection<OrderDetailModel> yourChoiceList = new ObservableCollection<OrderDetailModel>();
        public static ObservableCollection<OrderDetailModel> linkList = new ObservableCollection<OrderDetailModel>();
        public static ObservableCollection<OrderDetailModel> productDetail = new ObservableCollection<OrderDetailModel>();
        public static ObservableCollection<OrderDetailModel> groupProduct = new ObservableCollection<OrderDetailModel>();

        public static ObservableCollection<OrderDetailModel> extract(string result)
        {
            OrderDetailModel order = new OrderDetailModel();
            ObservableCollection<OrderDetailModel> content = new ObservableCollection<OrderDetailModel>();
            XDocument xdoc = XDocument.Parse(result);

            yourChoiceList = new ObservableCollection<OrderDetailModel>();
            linkList = new ObservableCollection<OrderDetailModel>();
            productDetail = new ObservableCollection<OrderDetailModel>();
            groupProduct = new ObservableCollection<OrderDetailModel>();

            var product = from ack in xdoc.Descendants("Product")
                          select ack;

            if (product.Count() > 0)
            {
                ProductInfo.extract(product.ElementAt(0).ToString());
                int count = ProductInfo._definitions.ElementAt(0).features.Count;

                for (int i = 0; i < 10; i++)
                {

                }

                for (int i = 0; i < ProductDefinition._links.Count; i++)
                {
                    order.link = ProductDefinition._links.ElementAt(i).title;
                    order.url = ProductDefinition._links.ElementAt(i).url;
                    order.listClickButton = "/NewExample;component/Images/balloon_disclosure.png";
                    linkList.Add(order);
                    order = new OrderDetailModel();
                }
                for (int i = 0; i < count; i++)
                {
                    order.featureType = ProductInfo._definitions.ElementAt(0).features.ElementAt(i).type;
                    if (order.featureType == 1)
                    {
                        order.title = Feature.test.ElementAt(i).title;
                        order.valueDesc = Feature.test.ElementAt(i).valueDesc;
                        order.valueVisible = Visibility.Visible;
                        order.imageVisible = Visibility.Visible;
                        order.tongleVisible = Visibility.Collapsed;
                        order.listClickButton = "/NewExample;component/Images/balloon_disclosure.png";
                        yourChoiceList.Add(order);
                        order = new OrderDetailModel();
                    }
                    if (order.featureType == 2)
                    {
                        order.title = Feature.test.ElementAt(i).title;
                        order.isCheck = bool.Parse(Feature.test.ElementAt(i).value);
                        order.valueVisible = Visibility.Collapsed;
                        order.imageVisible = Visibility.Collapsed;
                        order.tongleVisible = Visibility.Visible;
                        yourChoiceList.Add(order);
                        order = new OrderDetailModel();
                    }
                    if (order.featureType == 3)
                    {
                        order.title = Feature.test.ElementAt(i).title;
                        order.valueDesc = Feature.test.ElementAt(i).valueDesc;
                        productDetail.Add(order);
                        order = new OrderDetailModel();
                    }
                }

                order.desc = ProductInfo._definitions.ElementAt(0).desc;
                content.Add(order);
                order = new OrderDetailModel();
            }
            return content;
        }

    }
}
