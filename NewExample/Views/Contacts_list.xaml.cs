
using System.Linq;
using Microsoft.Phone.Controls;
using System.Windows;
using Microsoft.Phone.UserData;
using System;
using System.Collections.Generic;

using Microsoft.Phone.Tasks;
using System.Windows.Controls;
using NewExample.ViewModel;
namespace NewExample.Views
{
    public partial class Contacts_list : PhoneApplicationPage
    {
        Contacts cons;
        List<Contact_Class> contactList = new List<Contact_Class>();
        private string displayName = "Andrew Hill";
        public Contacts_list()
        {
            InitializeComponent();
            Contact_listUIContainer.DataContext = new Contacts_list_ViewModel();
            //GetContact();
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
                //We can get attributes from each item
                contactList.Add(new Contact_Class() { fullname = item.DisplayName });
                // everynames += item.DisplayName + Environment.NewLine;
            }
            listBox1.ItemsSource = contactList;
            // MessageBox.Show(everynames);

            //IEnumerable<Contact> contacts = e.Results; //Here your result
            //string everynames = String.Empty;
            //foreach (var item in contacts)
            //{
            //    //We can get attributes from each item
            //    everynames += item.DisplayName + ";" //Get name
            //        + (item.EmailAddresses.Count() > 0 ? (item.EmailAddresses.FirstOrDefault()).EmailAddress : "") + ";" //Check if contact has an email. If so, display it. He can be more than one !
            //        + (item.PhoneNumbers.Count() > 0 ? (item.PhoneNumbers.FirstOrDefault()).PhoneNumber : "") + ";" //Check if contact has a phonenumber. If so, display it. He can be more than one !
            //        + Environment.NewLine;
            //}
            //MessageBox.Show(everynames);

        }

        private void listBox1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            Contact_Class selectedItem = (Contact_Class)listbox.SelectedItem;
            displayName = selectedItem.fullname;
            Contacts contacts = new Contacts();
            contacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contacts_SearchCompleted);
            contacts.SearchAsync(displayName, FilterKind.DisplayName, null);
        }

        void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            foreach (var result in e.Results)
            {
                this.tbdisplayName.Text = "Name: " + result.DisplayName;
                this.tbEmail.Text = "E-mail address: " + (result.EmailAddresses.Count() > 0 ? (result.EmailAddresses.FirstOrDefault()).EmailAddress : "");
                this.tbPhone.Text = "Phone Number: " + (result.PhoneNumbers.Count() > 0 ? (result.PhoneNumbers.FirstOrDefault()).PhoneNumber : "");
                this.tbPhysicalAddress.Text = "Address: " + (result.Addresses.Count() > 0 ? (result.Addresses.FirstOrDefault()).PhysicalAddress.AddressLine1 : "");
                this.tbWebsite.Text = "Website: " + (result.Websites.Count() > 0 ? (result.Websites.FirstOrDefault()) : "");
            }
        }
    }

    public class Contact_Class
    {
        public string fullname { get; set; }
    }
}

