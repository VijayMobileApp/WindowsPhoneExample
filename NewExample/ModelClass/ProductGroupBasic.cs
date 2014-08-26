using System.Linq;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace NewExample.ModelClass
{
    public class ProductGroupBasic
    {
        public String _orderNo;
        public String orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public String _productId;
        public String productId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public static ProductGroupBasic extract(string productInfo)
        {
            String[] searchTags = { "ProductID", "GroupOrderNo" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            ProductGroupBasic product = new ProductGroupBasic();
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

            product.productId = result.ElementAt(0);
            product.orderNo = result.ElementAt(1);
            return product;
        }
    }
}
