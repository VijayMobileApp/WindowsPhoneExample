using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class ProductInfoBasic
    {
        public static string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public static DateTime _today;
        public DateTime today
        {
            get { return _today; }
            set { _today = value; }
        }

        public static bool _dateCountDown;
        public bool dateCountDown
        {
            get { return _dateCountDown; }
            set { _dateCountDown = value; }
        }

        public static string _shortName;
        public string shortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        public static string _exchangeTypeDesc;
        public string exchangeTypeDesc
        {
            get { return _exchangeTypeDesc; }
            set { _exchangeTypeDesc = value; }
        }

        public static string _brandFullTitle;
        public string brandFullTitle
        {
            get { return _brandFullTitle; }
            set { _brandFullTitle = value; }
        }

        public static bool _showPrice;
        public bool showPrice
        {
            get { return _showPrice; }
            set { _showPrice = value; }
        }

        public static double _listPriceValue;
        public double listPriceValue
        {
            get { return _listPriceValue; }
            set { _listPriceValue = value; }
        }

        public static double _priceValue;
        public double priceValue
        {
            get { return _priceValue; }
            set { _priceValue = value; }
        }

        public static DateTime _priceExpiryDate;
        public DateTime priceExpiryDate
        {
            get { return _priceExpiryDate; }
            set { _priceExpiryDate = value; }
        }

        public static string _thumbnailPhoto;
        public string thumbnailPhoto
        {
            get { return _thumbnailPhoto; }
            set { _thumbnailPhoto = value; }
        }

        public static OrganizationInfoBasic _owner;
        public OrganizationInfoBasic owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public static Ratings _ratings;
        public Ratings ratings
        {
            get { return _ratings; }
            set { _ratings = value; }
        }

        public ProductInfoBasic()
        {
        }


        public ProductInfoBasic(String identityInfo)
        {
            extract(identityInfo);
        }

        public static ProductInfoBasic extract(string personInformation)
        {

            String[] searchTags = { "ProductID", "Today", "DateCountDown", "ProductShortName", "ProductExchangeTypeDesc", "ProductBrandFullTitle", 
                                      "ShowPrice", "ProductListPriceValue", "ProductPriceValue", "ProductPriceExpiryDate", "PhotoThumbnail"};
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(personInformation);
            ProductInfoBasic prod = new ProductInfoBasic();
            XElement idnos = null;
            var ratings = from ack in xdoc.Descendants("Ratings")
                          select ack;
            var organizationInfo = from ack in xdoc.Descendants("OrganizationInfoBasic")
                                   select ack;

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
            prod.id = result.ElementAt(0);
            prod.today = DateTime.Parse(result.ElementAt(1));
            prod.dateCountDown = bool.Parse(result.ElementAt(2));
            prod.shortName = result.ElementAt(3);
            prod.exchangeTypeDesc = result.ElementAt(4);
            prod.brandFullTitle = result.ElementAt(5);
            prod.showPrice = bool.Parse(result.ElementAt(6));
            if (prod.showPrice)
            {
                prod.listPriceValue = double.Parse(result.ElementAt(7));
                prod.priceValue = double.Parse(result.ElementAt(8));
            }
            else
            {
                prod.listPriceValue = 0;
                prod.priceValue = 0;
            }

            prod.priceExpiryDate = DateTime.Parse(result.ElementAt(9));
            prod.thumbnailPhoto = result.ElementAt(10);
            prod.owner = OrganizationInfoBasic.extract(organizationInfo.ElementAt(0).ToString());
            prod.ratings = Ratings.extracts(ratings.ElementAt(0).ToString());
            return prod;
        }
    }
}
