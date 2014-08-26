using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ReactiveUI;
using ReactiveUI.Xaml;
using Microsoft.Phone.Tasks;

namespace NewExample.ViewModel
{
    public class EmailOrPhoneViewModel : ReactiveObject
    {
        public static string _phoneNumber;
        public string phoneNumber
        {
            get { return _phoneNumber; }
            set { this.RaiseAndSetIfChanged(x => x.phoneNumber, value); }
        }

        public static string _emailId;
        public string emailId
        {
            get { return _emailId; }
            set { this.RaiseAndSetIfChanged(x => x.emailId, value); }
        }
      
        public static string _smsNumber;
        public string smsNumber
        {
            get { return _smsNumber; }
            set { this.RaiseAndSetIfChanged(x => x.smsNumber, value); }
        }


        public static string _contact;
        public string contact
        {
            get { return _contact; }
            set { this.RaiseAndSetIfChanged(x => x.contact, value); }
        }
        public ReactiveAsyncCommand makeCall { get; set; }
        public ReactiveAsyncCommand sendMail { get; set; }
        public ReactiveAsyncCommand sendSms { get; set; }
        public ReactiveAsyncCommand selectContact { get; set; }

        PhoneNumberChooserTask phoneNumberChooserTask;

        public EmailOrPhoneViewModel()
        {
            phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);

            makeCall = new ReactiveAsyncCommand();
            makeCall.Subscribe(x =>
            {
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    PhoneCallTask phoneCallTask = new PhoneCallTask();
                    phoneCallTask.PhoneNumber = phoneNumber;
                    phoneCallTask.DisplayName = "Gage";
                    phoneCallTask.Show();
                }
            });

            sendMail = new ReactiveAsyncCommand();
            sendMail.Subscribe(x => {

                if (!string.IsNullOrEmpty(emailId))
                {
                    EmailComposeTask emailComposeTask = new EmailComposeTask();

                    emailComposeTask.Subject = "message subject";
                    emailComposeTask.Body = "message body";
                    emailComposeTask.To = emailId;
                    emailComposeTask.Cc = "cc@example.com";
                    emailComposeTask.Bcc = "bcc@example.com";
                    emailComposeTask.Show();
                }
            
            });

            sendSms = new ReactiveAsyncCommand();
            sendSms.Subscribe(x => {
                if (!string.IsNullOrEmpty(smsNumber))
                {
                    SmsComposeTask smsComposeTask = new SmsComposeTask();
                    smsComposeTask.To = smsNumber;
                    smsComposeTask.Body = "Try this new application. It's great!";
                    smsComposeTask.Show();
                }
            });

            selectContact = new ReactiveAsyncCommand();
            selectContact.Subscribe(x =>
            {
                phoneNumberChooserTask.Show();

            });
        }

        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show("The phone number for " + e.DisplayName + " is " + e.PhoneNumber);
                //Code to start a new call using the retrieved phone number.
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.DisplayName = e.DisplayName;
                phoneCallTask.PhoneNumber = e.PhoneNumber;
                contact = e.PhoneNumber;
                phoneCallTask.Show();
            }
        }

    }
}
