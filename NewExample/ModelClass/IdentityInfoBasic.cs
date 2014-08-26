using System;
using ReactiveUI;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class IdentityInfoBasic : ReactiveObject
    {
        public static string _identityNo;
        public string identityNo
        {
            get { return _identityNo; }
            set { this.RaiseAndSetIfChanged(x => x.identityNo, value); }
        }

        public static string _fullName;
        public string fullName
        {
            get { return _fullName; }
            set { this.RaiseAndSetIfChanged(x => x.fullName, value); }
        }

        public static Ratings _ratings;
        public Ratings ratings
        {
            get { return _ratings; }
            set { this.RaiseAndSetIfChanged(x => x.ratings, value); }
        }


        public static Dictionary<String, Address> _addressList;
        public Dictionary<String, Address> addressList
        {
            get { return _addressList; }
            set { this.RaiseAndSetIfChanged(x => x.addressList, value); }
        }

        public static Address _defaultAddress;
        public Address defaultAddress
        {
            get { return _defaultAddress; }
            set { this.RaiseAndSetIfChanged(x => x.defaultAddress, value); }
        }
        
        public static List<Photo> _photos;
        public List<Photo> photos
        {
            get { return _photos; }
            set { this.RaiseAndSetIfChanged(x => x.photos, value); }
        }

        public IdentityInfoBasic()
        {
        }


        public IdentityInfoBasic(String identityInfo)
        {
            extracts(identityInfo);
        }

        public static IdentityInfoBasic extracts(string identityInformation)
        {
            String[] searchTags = { "IdentityNo", "FullName" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(identityInformation);
            IdentityInfoBasic identity = new IdentityInfoBasic();
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

            identity.identityNo = result.ElementAt(0);
            identity.fullName = result.ElementAt(1);

            var address = from ack in xdoc.Descendants("Addresses")
                          select ack;

            var ratings = from ack in xdoc.Descendants("Ratings")
                          select ack;

            var photos = from ack in xdoc.Descendants("Photos")
                         select ack;

            if (address.Count() > 0)
                identity.defaultAddress = Address.extracts(address.ElementAt(0).ToString());

            if (ratings.Count() > 0)
                identity.ratings = Ratings.extracts(ratings.ElementAt(0).ToString());

            if (photos.Count() > 0)
            {
                identity.photos = new List<Photo>();
                int elementCount = photos.Count();
                for (int i = 0; i < elementCount; i++)
                {
                    Photo Objphoto = new Photo(photos.ElementAt(i).ToString());
                    identity.photos.Add(Objphoto);
                }
            }
            return identity;
        }
    }
}
