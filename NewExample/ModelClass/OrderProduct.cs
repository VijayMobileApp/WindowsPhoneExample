using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System;

namespace NewExample.ModelClass
{
    public class OrderProduct
    {
        public static string _itemKey;
        public string itemKey
        {
            get { return _itemKey; }
            set { _itemKey = value; }
        }

        public static int _orderNo;
        public int orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public static int _count;
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        public static double _totalListPrice;
        public double totalListPrice
        {
            get { return _totalListPrice; }
            set { _totalListPrice = value; }
        }

        public static double _totalPrice;
        public double totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public static string _exchangeType;
        public string exchangeType
        {
            get { return _exchangeType; }
            set { _exchangeType = value; }
        }

        public static string _exchangeTypeDesc;
        public string exchangeTypeDesc
        {
            get { return _exchangeTypeDesc; }
            set { _exchangeTypeDesc = value; }
        }

        public static string _itemStatus;
        public string itemStatus
        {
            get { return _itemStatus; }
            set { _itemStatus = value; }
        }


        public static string _itemStatusDesc;
        public string itemStatusDesc
        {
            get { return _itemStatusDesc; }
            set { _itemStatusDesc = value; }
        }


        public static ProductInfoBasic _product;
        public ProductInfoBasic product
        {
            get { return _product; }
            set { _product = value; }
        }

        public static Dictionary<String, FeatureBasic> _basicFeatures;
        public Dictionary<String, FeatureBasic> basicFeatures
        {
            get { return _basicFeatures; }
            set { _basicFeatures = value; }
        }

        public static Dictionary<String, ProductGroupBasic> _basicProductGroups;
        public Dictionary<String, ProductGroupBasic> basicProductGroups
        {
            get { return _basicProductGroups; }
            set { _basicProductGroups = value; }
        }

        public static Dictionary<String, ProductGroupBasic> getbasicProductGroup = new Dictionary<String, ProductGroupBasic>();

        public static OrderProduct extract(string productInformation)
        {
            string[] searchTags = { "OrderItemKey", "CartItemKey", "OrderNo", "Count", "TotalListPrice", "TotalPrice", "ExchangeType", "ExchangeTypeDesc", "OrderItemStatus", "OrderItemStatusDesc" };
            List<string> result = new List<string>();
            XDocument xdoc = XDocument.Parse(productInformation);

            var productInfoBasic = from ack in xdoc.Descendants("ProductInfoBasic")
                                   select ack;

            var productGroup = from ack in xdoc.Descendants("ProductGroup")
                               select ack;

            var feature = from ack in xdoc.Descendants("Feature")
                          select ack;

            OrderProduct person = new OrderProduct();
            XElement idnos = null;
            for (int i = 0; i < searchTags.Length; i++)
            {
                try
                {
                    idnos = xdoc.Descendants()
                        .Where(pp => pp.Name == searchTags[i])
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    idnos = null;
                }
                finally
                {
                    result.Add(((null == idnos) || (null == idnos.Value)) ? "" : idnos.Value);
                }

            }
            if (!string.IsNullOrEmpty(result.ElementAt(0)))
                person.itemKey = result.ElementAt(0);
            else
                person.itemKey = result.ElementAt(1);

            person.orderNo = int.Parse(result.ElementAt(2));
            person.count = int.Parse(result.ElementAt(3));
            person.totalListPrice = double.Parse(result.ElementAt(4));
            person.totalPrice = double.Parse(result.ElementAt(5));
            person.exchangeType = result.ElementAt(6);
            person.exchangeTypeDesc = result.ElementAt(7);
            person.itemStatus = result.ElementAt(8);
            person.itemStatusDesc = result.ElementAt(9);

            if (productInfoBasic.Count() > 0)
                person.product = ProductInfoBasic.extract(productInfoBasic.ElementAt(0).ToString());



            if (productGroup.Count() > 0)
            {
                ProductGroupBasic pgb;
                person.basicProductGroups = new Dictionary<String, ProductGroupBasic>();
                for (int i = 0; i < productGroup.Count(); i++)
                {
                    pgb = new ProductGroupBasic();
                    pgb = ProductGroupBasic.extract(productGroup.ElementAt(i).ToString());
                    person.basicProductGroups.Add(pgb._orderNo, pgb);
                    //getbasicProductGroup.Add(pgb._orderNo, pgb);
                }
            }
            Console.WriteLine("basicProductGroups.Keys count=====> " + person.basicProductGroups.Keys.Count);

            //foreach (string key in person.basicProductGroups.Keys)
            //{
            //    Console.WriteLine("Key: {0}\nValue{1}", key, person.basicProductGroups[key].ToString());
            //}

            if (feature.Count() > 0)
            {
                FeatureBasic fb;
                person.basicFeatures = new Dictionary<String, FeatureBasic>();
                for (int i = 0; i < feature.Count(); i++)
                {
                    fb = new FeatureBasic();
                    fb = FeatureBasic.extract(feature.ElementAt(i).ToString());
                    person.basicFeatures.Add(fb._id, fb);
                }
            }

            //foreach (string key in person.basicFeatures.Keys)
            //{
            //    Console.WriteLine("Key: {0}\nValue{1}", key, person.basicFeatures[key]._valueDesc.ToString());
            //}
            return person;
        }
    }
}
