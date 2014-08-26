using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class GroupProductInfoBasic : ProductInfoBasic
    {
        public int _orderNo;
        public int orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public double _price;
        public double price
        {
            get { return _price; }
            set { _price = value; }
        }


        public double _percentage;
        public double percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }

        public bool _defaultOf;
        public bool defaultOf
        {
            get { return _defaultOf; }
            set { _defaultOf = value; }
        }

        public String _groupName;
        public String groupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        public GroupProductInfoBasic()
            : base()
        {

        }


        public GroupProductInfoBasic(string productInformation)
            : base(productInformation)
        {

        }



        public static GroupProductInfoBasic extracts(string productInfo)
        {
            String[] searchTags = { "ProductOrderNo", "Price", "Percentage", "Default", "Price" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            GroupProductInfoBasic product = new GroupProductInfoBasic(productInfo);
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
            product.orderNo = int.Parse(result.ElementAt(0));
            product.price = double.Parse(result.ElementAt(1));
            product.percentage = double.Parse(result.ElementAt(2));
            product.defaultOf = bool.Parse(result.ElementAt(3));
            return product;
        }
    }
}
