using ReactiveUI;
using NewExample.Model;
using System.Collections.ObjectModel;
using ReactiveUI.Xaml;
using System;
using Microsoft.Phone.UserData;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace NewExample.ViewModel
{
    public class Contacts_list_ViewModel : ReactiveObject
    {
        Contacts cons;

        public static ObservableCollection<Contact_list_Model> _contactDetails;
        public ObservableCollection<Contact_list_Model> contactDetails
        {
            get { return _contactDetails; }
            set { this.RaiseAndSetIfChanged(x => x.contactDetails, value); }
        }

        private Contact_list_Model selectedName;
        public Contact_list_Model SelectedName
        {
            get { return selectedName; }

            set
            {
                if (selectedName == value)
                    return;
                selectedName = value;

                //MessageBox.Show(selectedName.fullname);
                displayName = selectedName.fullname;
                ContactDetail();
                //var rootFrame = (App.Current as App).RootFrame;
                //rootFrame.Navigate(new Uri("/com/beno/WP7Client/Views/CommentFeedPage.xaml", UriKind.Relative));
            }
        }

        public string _displayName;
        public string displayName
        {
            get { return _displayName; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.displayName, value);
            }
        }

        public string _conname;
        public string conname
        {
            get { return _conname; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.conname, value);
            }
        }

        public string _email;
        public string email
        {
            get { return _email; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.email, value);
            }
        }

        public string _phone;
        public string phone
        {
            get { return _phone; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.phone, value);
            }
        }

        public string _address;
        public string address
        {
            get { return _address; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.address, value);
            }
        }

        public string _website;
        public string website
        {
            get { return _website; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.website, value);
            }
        }

        public Image _image;
        public Image image
        {
            get { return _image; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.image, value);
            }
        }



        public Contacts_list_ViewModel()
        {
            var getContactsDetails = new ReactiveAsyncCommand();

            getContactsDetails.Subscribe(x =>
            {
                contactDetails = new ObservableCollection<Contact_list_Model>();
                GetContact();

            });
            getContactsDetails.Execute(true);
        }

        void GetContact()
        {
            cons = new Contacts();
            //Identify the method that runs after the asynchronous search completes.
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(ContactsSearchCompleted);
            //Start the asynchronous search.
            cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");
        }

        private void ContactsSearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            cons.SearchCompleted -= ContactsSearchCompleted;
            IEnumerable<Contact> contacts = e.Results; //Here your result

            foreach (var item in contacts)
            {
                contactDetails.Add(new Contact_list_Model() { fullname = item.DisplayName });
            }
        }

        void ContactDetail()
        {
            Contacts contacts = new Contacts();
            contacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contacts_SearchCompleted);
            contacts.SearchAsync(displayName, FilterKind.DisplayName, null);

        }

        void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            foreach (var result in e.Results)
            {
                try
                {
                    BitmapImage img = new BitmapImage();
                    img.SetSource(result.GetPicture());
                    image.Source = img;
                }
                catch (Exception)
                {
                    //We can't get a picture of the contact.
                }
                conname = "Name: " + result.DisplayName;
                email = "E-mail address: " + (result.EmailAddresses.Count() > 0 ? (result.EmailAddresses.FirstOrDefault()).EmailAddress : "");
                phone = "Phone Number: " + (result.PhoneNumbers.Count() > 0 ? (result.PhoneNumbers.FirstOrDefault()).PhoneNumber : "");
                address = "Address: " + (result.Addresses.Count() > 0 ? (result.Addresses.FirstOrDefault()).PhysicalAddress.AddressLine1 : "");
                website = "Website: " + (result.Websites.Count() > 0 ? (result.Websites.FirstOrDefault()) : "");
                //string name = "Name: " + result.DisplayName;
                //string tbEmail = "E-mail address: " + (result.EmailAddresses.Count() > 0 ? (result.EmailAddresses.FirstOrDefault()).EmailAddress : "");
                //this.tbPhone.Text = "Phone Number: " + (result.PhoneNumbers.Count() > 0 ? (result.PhoneNumbers.FirstOrDefault()).PhoneNumber : "");
                //this.tbPhysicalAddress.Text = "Address: " + (result.Addresses.Count() > 0 ? (result.Addresses.FirstOrDefault()).PhysicalAddress.AddressLine1 : "");
                //this.tbWebsite.Text = "Website: " + (result.Websites.Count() > 0 ? (result.Websites.FirstOrDefault()) : "");

                // MessageBox.Show("Name==>  " + name + "     Email==>  " + tbEmail);
            }
        }

    }
}
