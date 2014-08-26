using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using ReactiveUI;
using System.Device.Location;
using NewExample.Const;

namespace NewExample.ModelClass
{
    public class Address : ReactiveObject
    {
        public static string _id;
        public string id
        {
            get { return _id; }
            set { this.RaiseAndSetIfChanged(x => x.id, value); }
        }

        public static string _name;
        public string name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(x => x.name, value); }
        }

        public static string _country;
        public string country
        {
            get { return _country; }
            set { this.RaiseAndSetIfChanged(x => x.country, value); }
        }

        public static string _countryDesc;
        public string countryDesc
        {
            get { return _countryDesc; }
            set { this.RaiseAndSetIfChanged(x => x.countryDesc, value); }
        }

        public static string _state;
        public string state
        {
            get { return _state; }
            set { this.RaiseAndSetIfChanged(x => x.state, value); }
        }

        public static string _stateDesc;
        public string stateDesc
        {
            get { return _stateDesc; }
            set { this.RaiseAndSetIfChanged(x => x.stateDesc, value); }
        }


        public static string _city;
        public string city
        {
            get { return _city; }
            set { this.RaiseAndSetIfChanged(x => x.city, value); }
        }

        public static string _cityDesc;
        public string cityDesc
        {
            get { return _cityDesc; }
            set { this.RaiseAndSetIfChanged(x => x.cityDesc, value); }
        }

        public static string _town;
        public string town
        {
            get { return _town; }
            set { this.RaiseAndSetIfChanged(x => x.town, value); }
        }

        public static string _townDesc;
        public string townDesc
        {
            get { return _townDesc; }
            set { this.RaiseAndSetIfChanged(x => x.townDesc, value); }
        }

        public static string _district;
        public string district
        {
            get { return _district; }
            set { this.RaiseAndSetIfChanged(x => x.district, value); }
        }


        public static string _districtDesc;
        public string districtDesc
        {
            get { return _districtDesc; }
            set { this.RaiseAndSetIfChanged(x => x.districtDesc, value); }
        }

        public static string _postCode;
        public string postCode
        {
            get { return _postCode; }
            set { this.RaiseAndSetIfChanged(x => x.postCode, value); }
        }

        public static string _other;
        public string other
        {
            get { return _other; }
            set { this.RaiseAndSetIfChanged(x => x.other, value); }
        }

        public static DateTime _createdTime;
        public DateTime createdTime
        {
            get { return _createdTime; }
            set { this.RaiseAndSetIfChanged(x => x.createdTime, value); }
        }

        public static string _createdTimeOP;
        public string createdTimeOP
        {
            get { return _createdTimeOP; }
            set { this.RaiseAndSetIfChanged(x => x.createdTimeOP, value); }
        }

        public static string _detailedDescription;
        public string detailedDescription
        {
            get { return _detailedDescription; }
            set { this.RaiseAndSetIfChanged(x => x.detailedDescription, value); }
        }

        public static string _geoLocation;
        public string geoLocation
        {
            get { return _geoLocation; }
            set { this.RaiseAndSetIfChanged(x => x.geoLocation, value); }
        }

        public static double _latitude;
        public double latitude
        {
            get { return _latitude; }
            set { this.RaiseAndSetIfChanged(x => x.latitude, value); }
        }

        public static double _logitude;
        public double logitude
        {
            get { return _logitude; }
            set { this.RaiseAndSetIfChanged(x => x.logitude, value); }
        }

        public static string _kilometer;
        public string kilometer
        {
            get { return _kilometer; }
            set { this.RaiseAndSetIfChanged(x => x.kilometer, value); }
        }



        public static bool _defaultAddress;
        public bool defaultAddress
        {
            get { return _defaultAddress; }
            set { this.RaiseAndSetIfChanged(x => x.defaultAddress, value); }
        }


        public static Address extracts(string identityInformation)
        {
            String[] searchTags = { "AddressID", "AddressName", "Country", "CountryDesc", 
                                      "State", "StateDesc", "City", "CityDesc", "Town", "TownDesc", 
                                       "District", "DistrictDesc", "PostCode", "Other", 
                                      "CreatedTime", "DetailedDescription", "GeoLocation", "IsDefaultAddress" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(identityInformation);
            Address addres = new Address();
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
            addres.id = result.ElementAt(0);
            addres.name = result.ElementAt(1);
            addres.country = result.ElementAt(2);
            addres.countryDesc = result.ElementAt(3);
            addres.state = result.ElementAt(4);
            addres.stateDesc = result.ElementAt(5);
            addres.city = result.ElementAt(6);
            addres.cityDesc = result.ElementAt(7);
            addres.town = result.ElementAt(8);
            addres.townDesc = result.ElementAt(9);
            addres.district = result.ElementAt(10);
            addres.districtDesc = result.ElementAt(11);
            addres.postCode = result.ElementAt(12);
            addres.other = result.ElementAt(13);
            if ((null != result.ElementAt(14)) && !(String.IsNullOrEmpty(result.ElementAt(14))))
            {
                addres.createdTime = DateTime.Parse(result.ElementAt(14));
                addres.createdTimeOP = addres.createdTime.ToString("d/M/yyyy");
            }
            else
                addres.createdTimeOP = "";

            addres.detailedDescription = result.ElementAt(15);
            addres.geoLocation = result.ElementAt(16);
            if (!string.IsNullOrEmpty(addres.geoLocation))
            {
                string str = addres.geoLocation;
                string[] nameParts = str.Split(',');
                addres.latitude = double.Parse(nameParts[0]);
                addres.logitude = double.Parse(nameParts[1]);
                //To calculate the Distance between two coordinates.
                var sCoord = new GeoCoordinate(addres.latitude, addres.logitude);
                var eCoord = new GeoCoordinate(double.Parse(AppConstant.latitude), double.Parse(AppConstant.longitude));
                double dist = sCoord.GetDistanceTo(eCoord);
                double km = dist / 1000;
                addres.kilometer = km.ToString("0.00") + " KM";
            }
            if ((null != result.ElementAt(17)) && !(String.IsNullOrEmpty(result.ElementAt(17))))
            {
                addres.defaultAddress = bool.Parse(result.ElementAt(17));
            }
            return addres;
        }
    }
}
