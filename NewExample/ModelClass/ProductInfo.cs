
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
namespace NewExample.ModelClass
{
    public class ProductInfo
    {
        public string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime _today;
        public DateTime today
        {
            get { return _today; }
            set { _today = value; }
        }

        public string _createDate;
        public string createDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public bool _dateCountDown;
        public bool dateCountDown
        {
            get { return _dateCountDown; }
            set { _dateCountDown = value; }
        }

        public bool _showPrice;
        public bool showPrice
        {
            get { return _showPrice; }
            set { _showPrice = value; }
        }

        public string _productQR;
        public string productQR
        {
            get { return _productQR; }
            set { _productQR = value; }
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

        //public static Brand _brand;
        //public Brand brand
        //{
        //    get { return _brand; }
        //    set { _brand = value; }
        //}

        //public static List<ProductProvider> _providers;
        //public List<ProductProvider> providers
        //{
        //    get { return _providers; }
        //    set { _providers = value; }
        //}

        public static List<ProductDefinition> _definitions;
        public List<ProductDefinition> definitions
        {
            get { return _definitions; }
            set { _definitions = value; }
        }

        //public static MainFeatureGroup _mainFeatureGroup;
        //public MainFeatureGroup mainFeatureGroup
        //{
        //    get { return _mainFeatureGroup; }
        //    set { _mainFeatureGroup = value; }
        //}

        public string _taxId;
        public string taxId
        {
            get { return _taxId; }
            set { _taxId = value; }
        }

        public string _taxDesc;
        public string taxDesc
        {
            get { return _taxDesc; }
            set { _taxDesc = value; }
        }

        public int _stockUnit;
        public int stockUnit
        {
            get { return _stockUnit; }
            set { _stockUnit = value; }
        }

        public string _stockUnitDesc;
        public string stockUnitDesc
        {
            get { return _stockUnitDesc; }
            set { _stockUnitDesc = value; }
        }

        public string _exchangeType;
        public string exchangeType
        {
            get { return _exchangeType; }
            set { _exchangeType = value; }
        }

        public string _exchangeTypeDesc;
        public string exchangeTypeDesc
        {
            get { return _exchangeTypeDesc; }
            set { _exchangeTypeDesc = value; }
        }

        //public static List<ProductListPrice> _listPrices;
        //public List<ProductListPrice> listPrices
        //{
        //    get { return _listPrices; }
        //    set { _listPrices = value; }
        //}

        //public static List<ProductPrice> _prices;
        //public List<ProductPrice> prices
        //{
        //    get { return _prices; }
        //    set { _prices = value; }
        //}

        //public static List<ProductServiceType> _serviceTypes;
        //public List<ProductServiceType> serviceTypes
        //{
        //    get { return _serviceTypes; }
        //    set { _serviceTypes = value; }
        //}

        public static List<Photo> _photos;
        public List<Photo> photos
        {
            get { return _photos; }
            set { _photos = value; }
        }

        public static Photo _defaultPhoto;
        public Photo defaultPhoto
        {
            get { return _defaultPhoto; }
            set { _defaultPhoto = value; }
        }

        public static List<ProductGroup> _productGroups;
        public List<ProductGroup> productGroups
        {
            get { return _productGroups; }
            set { _productGroups = value; }
        }

        //public static List<ProductInfoBasic> _relatedProducts;
        //public List<ProductInfoBasic> relatedProducts
        //{
        //    get { return _relatedProducts; }
        //    set { _relatedProducts = value; }
        //}

        public static DateTime creationDate;
        public static DateTime memberDate;
        public static ProductInfo extract(string productInfo)
        {

            String[] searchTags = { "ProductID", "Today", "DateCountDown", "ShowPrice", "ProductQR", "TaxID", "TaxDesc", "ProductStockUnit", "ProductStockUnitDesc", "ProductExchangeType", "ProductExchangeTypeDesc" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(productInfo);
            ProductInfo product = new ProductInfo();
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

            product.id = result.ElementAt(0);
            if ((null != result.ElementAt(1)) && !(String.IsNullOrEmpty(result.ElementAt(1))))
            {
                product.today = DateTime.Parse(result.ElementAt(1), System.Globalization.CultureInfo.InvariantCulture);
                product.createDate = product.today.ToUniversalTime().ToString("MMM d, yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            }
            else
                product.createDate = "";

            product.dateCountDown = bool.Parse(result.ElementAt(2));
            product.showPrice = bool.Parse(result.ElementAt(3));
            product.productQR = result.ElementAt(4);
            product.taxId = result.ElementAt(5);
            product.taxDesc = result.ElementAt(6);
            product.stockUnit = int.Parse(result.ElementAt(7));
            product.stockUnitDesc = result.ElementAt(8);
            product.exchangeType = result.ElementAt(9);
            product.exchangeTypeDesc = result.ElementAt(10);

            //var productListPricesRes = from ack in xdoc.Descendants("ProductListPrices")
            //                           select ack;

            //var productPricesRes = from ack in xdoc.Descendants("ProductPrices")
            //                       select ack;

            //var photosRes = from ack in xdoc.Descendants("Photos")
            //                select ack;

            //var productGroupsRes = from ack in xdoc.Descendants("ProductGroups")
            //                       select ack;

            //var productServiceTypesRes = from ack in xdoc.Descendants("ProductServiceTypes")
            //                             select ack;


            //var relatedProductsRes = from ack in xdoc.Descendants("RelatedProducts")
            //                         select ack;

            //var mainFeatureGroupRes = from ack in xdoc.Descendants("MainFeatureGroup")
            //                          select ack;

            var organizationInfoBasicRes = from ack in xdoc.Descendants("OrganizationInfoBasic")
                                           select ack;

            //var ratingsRes = from ack in organizationInfoBasicRes.Descendants("Ratings")
            //                 select ack;

            //var brandRes = from ack in organizationInfoBasicRes.Descendants("Brand")
            //               select ack;


            //var productProvidersRes = from ack in xdoc.Descendants("ProductProviders")
            //                          select ack;


            var productDefinitionsRes = from ack in xdoc.Descendants("ProductDefinitions")
            select ack;



          
            if (organizationInfoBasicRes.Count() > 0)
            {
                product.owner = OrganizationInfoBasic.extract(organizationInfoBasicRes.ElementAt(0).ToString());
                //for (int i = 0; i < organizationInfoBasicRes.Count(); i++)
                //    product.owner.Add(ProductDefinition.extract(organizationInfoBasicRes.ElementAt(i).ToString()));
            }

            product.definitions = new List<ProductDefinition>();
            if (productDefinitionsRes.Count() > 0)
            {
                for (int i = 0; i < productDefinitionsRes.Count(); i++)
                    product.definitions.Add(ProductDefinition.extract(productDefinitionsRes.ElementAt(i).ToString()));
            }

            return product;
        }

    }
}
