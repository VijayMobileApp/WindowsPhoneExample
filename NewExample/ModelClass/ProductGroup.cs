

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
namespace NewExample.ModelClass
{
    public class ProductGroup
    {
        public string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int _orderNo;
        public int orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public List<GroupProductInfoBasic> _groupProducts;
        public List<GroupProductInfoBasic> groupProducts
        {
            get { return _groupProducts; }
            set { _groupProducts = value; }
        }

        public List<ProductInfoBasic> _products;
        public List<ProductInfoBasic> products
        {
            get { return _products; }
            set { _products = value; }
        }

        public GroupProductInfoBasic _defaultProduct;
        public GroupProductInfoBasic defaultProduct
        {
            get { return _defaultProduct; }
            set { _defaultProduct = value; }
        }

        public static List<ProductGroup> test = new List<ProductGroup>();

        public static ProductGroup extract(string productInfo)
        {
            String[] searchTags = { "ProductGroupName", "GroupOrderNo" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            ProductGroup product = new ProductGroup();
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

            product.name = result.ElementAt(0);
            product.orderNo = int.Parse(result.ElementAt(1));


            var groupProducts = from ack in xdoc.Descendants("GroupProducts")
                                select ack;

            var groupProduct = from ack in groupProducts.Descendants("GroupProduct")
                               select ack;

            if (groupProduct.Count() > 0)
            {
                GroupProductInfoBasic groupInfo;
                product.groupProducts = new List<GroupProductInfoBasic>();
                for (int i = 0; i < groupProduct.Count(); i++)
                {
                    groupInfo = new GroupProductInfoBasic();
                    //groupInfo = GroupProductInfoBasic.extracts(groupProduct.ElementAt(i).ToString());
                    product.groupProducts.Add(GroupProductInfoBasic.extracts(groupProduct.ElementAt(i).ToString()));
                    //product.products.Add(groupInfo);
                    groupInfo._groupName = product.name;
                    if (product.groupProducts.ElementAt(i)._defaultOf)
                        product.defaultProduct = groupInfo;
                }

                for (int i = 0; i < product.groupProducts.Count; i++)
                    Console.WriteLine("short name==>  " + product.groupProducts.ElementAt(i).shortName);

                
            }

            return product;

        }
    }
}
