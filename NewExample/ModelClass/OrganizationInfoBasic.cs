using System;
using ReactiveUI;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class OrganizationInfoBasic : IdentityInfoBasic
    {
        public static string _thumbnailPhoto;
        public string thumbnailPhoto
        {
            get { return _thumbnailPhoto; }
            set { this.RaiseAndSetIfChanged(x => x.thumbnailPhoto, value); }
        }

        public static string _identityType;
        public string identityType
        {
            get { return _identityType; }
            set { this.RaiseAndSetIfChanged(x => x.identityType, value); }
        }

        public static DateTime _entryDate;
        public DateTime entryDate
        {
            get { return _entryDate; }
            set { this.RaiseAndSetIfChanged(x => x.entryDate, value); }
        }

        public static string _createDate;
        public string createDate
        {
            get { return _createDate; }
            set { this.RaiseAndSetIfChanged(x => x.createDate, value); }
        }

        public static string _partnershipGeneralDoc;
        public string partnershipGeneralDoc
        {
            get { return _partnershipGeneralDoc; }
            set { this.RaiseAndSetIfChanged(x => x.partnershipGeneralDoc, value); }
        }

        public static string _partnershipExclusiveDoc;
        public string partnershipExclusiveDoc
        {
            get { return _partnershipExclusiveDoc; }
            set { this.RaiseAndSetIfChanged(x => x.partnershipExclusiveDoc, value); }
        }

        public static bool _contact;
        public bool contact
        {
            get { return _contact; }
            set { this.RaiseAndSetIfChanged(x => x.contact, value); }
        }

        public static DateTime _membershipDate;
        public DateTime membershipDate
        {
            get { return _membershipDate; }
            set { this.RaiseAndSetIfChanged(x => x.membershipDate, value); }
        }

        public static string _MemberDate;
        public string MemberDate
        {
            get { return _MemberDate; }
            set { this.RaiseAndSetIfChanged(x => x.MemberDate, value); }
        }


        public OrganizationInfoBasic()
            : base()
        {

        }


        public OrganizationInfoBasic(string organizationInformation)
            : base(organizationInformation)
        {

        }


        public static DateTime creationDate;
        public static DateTime memberDate;
        public static OrganizationInfoBasic extract(string organizationInformation)
        {
            String[] searchTags = { "ThumbnailPhoto", "IdentityType", "EntryDate", "PartnershipGeneralDoc", "PartnershipExclusiveDoc", "IsContact", "MembershipDate" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(organizationInformation);
            OrganizationInfoBasic identity = new OrganizationInfoBasic(organizationInformation);
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

            identity.thumbnailPhoto = result.ElementAt(0);
            identity.identityType = result.ElementAt(1);
            if ((null != result.ElementAt(2)) && !(String.IsNullOrEmpty(result.ElementAt(2))))
            {
                creationDate = DateTime.Parse(result.ElementAt(2), System.Globalization.CultureInfo.InvariantCulture);
                identity.createDate = creationDate.ToUniversalTime().ToString("MMM d, yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            }
            else
                identity.createDate = "";
            identity.partnershipGeneralDoc = result.ElementAt(3);
            identity.partnershipExclusiveDoc = result.ElementAt(4);

            if ((null != result.ElementAt(5)) && !(String.IsNullOrEmpty(result.ElementAt(5))))
                identity.contact = bool.Parse(result.ElementAt(5));

            if ((null != result.ElementAt(6)) && !(String.IsNullOrEmpty(result.ElementAt(6))))
            {
                memberDate = DateTime.Parse(result.ElementAt(6), System.Globalization.CultureInfo.InvariantCulture);
                identity.MemberDate = creationDate.ToUniversalTime().ToString("MMM d, yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
                identity.MemberDate = "";
            return identity;
        }
    }
}
