using System;
using Facebook;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using ReactiveUI.Xaml;
using ReactiveUI;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;

namespace NewExample.ViewModel
{
    public class FacebookInfoPageViewModel : ReactiveObject
    {
        private string _accessToken;
        private string _userId;
        private string _lastMessageId;

        public string _txtMessage;
        public string txtMessage
        {
            get { return _txtMessage; }
            set { this.RaiseAndSetIfChanged(x => x.txtMessage, value); }
        }


        public string _ProfileName;
        public string ProfileName
        {
            get { return _ProfileName; }
            set { this.RaiseAndSetIfChanged(x => x.ProfileName, value); }
        }

        public string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { this.RaiseAndSetIfChanged(x => x.FirstName, value); }
        }

        public string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { this.RaiseAndSetIfChanged(x => x.LastName, value); }
        }

        public BitmapImage _picProfile;
        public BitmapImage picProfile
        {
            get { return _picProfile; }
            set { this.RaiseAndSetIfChanged(x => x.picProfile, value); }
        }

        public bool _btnDeleteLastMessage = false;
        public bool btnDeleteLastMessage
        {
            get { return _btnDeleteLastMessage; }
            set { this.RaiseAndSetIfChanged(x => x.btnDeleteLastMessage, value); }
        }


        public ReactiveCommand postCommand { get; set; }
        public ReactiveCommand deleteCommand { get; set; }

        public ReactiveAsyncCommand logoutButton { get; set; }

        public FacebookInfoPageViewModel(string _accessToken, string _userId)
        {
            this._accessToken = _accessToken;
            this._userId = _userId;
            LoadFacebookData();

            postCommand = new ReactiveCommand();
            postCommand.Subscribe(x =>
            {
                if (string.IsNullOrEmpty(txtMessage))
                {
                    MessageBox.Show("Enter message.");
                    return;
                }

                var fb = new FacebookClient(_accessToken);

                fb.PostCompleted += (o, args) =>
                {
                    if (args.Error != null)
                    {
                        Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                        return;
                    }

                    var result = (IDictionary<string, object>)args.GetResultData();
                    _lastMessageId = (string)result["id"];

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show("Message Posted successfully");

                        txtMessage = string.Empty;
                        btnDeleteLastMessage = true;
                    });
                };

                var parameters = new Dictionary<string, object>();
                parameters["message"] = txtMessage;

                fb.PostAsync("me/feed", parameters);
            });

            deleteCommand = new ReactiveCommand();
            deleteCommand.Subscribe(x =>
            {
                btnDeleteLastMessage = false;

                var fb = new FacebookClient(_accessToken);

                fb.DeleteCompleted += (o, args) =>
                {
                    if (args.Error != null)
                    {
                        Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                        return;
                    }

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show("Message deleted successfully");
                        btnDeleteLastMessage = false;
                    });
                };

                fb.DeleteAsync(_lastMessageId);

            });

            logoutButton = new ReactiveAsyncCommand();
            logoutButton.Subscribe(x => {
                FacebookLoginPageViewModel.logoutSession();
                var url = "/Views/IndexPage4.xaml";
                var rootFrame = (App.Current as App).RootFrame;
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    rootFrame.Navigate(new Uri(url, UriKind.Relative));
                });
            });
        }

        private void LoadFacebookData()
        {
            GetUserProfilePicture();

            GraphApiSample();

            FqlSample();
        }

        private void GetUserProfilePicture()
        {
            // available picture types: square (50x50), small (50xvariable height), large (about 200x variable height) (all size in pixels)
            // for more info visit http://developers.facebook.com/docs/reference/api
            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", _userId, "square", _accessToken);

            picProfile = new BitmapImage(new Uri(profilePictureUrl));

            
        }

        private void GraphApiSample()
        {
            var fb = new FacebookClient(_accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                  {
                      MessageBox.Show(e.Error.Message);
                  });
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();

                foreach (var pair in result)
                {
                    Debug.WriteLine("{0}=> , {1}",
                    pair.Key,
                    pair.Value);
                }

                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    ProfileName = "Hi " + (string)result["name"];
                    FirstName = "First Name: " + (string)result["first_name"];
                    FirstName = "Last Name: " + (string)result["last_name"];
                });
            };

            fb.GetAsync("me");
        }

        private void FqlSample()
        {
            var fb = new FacebookClient(_accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                var data = (IList<object>)result["data"];

                var count = data.Count;

                // since this is an async callback, make sure to be on the right thread
                // when working with the UI.
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    //TotalFriends.Text = string.Format("You have {0} friend(s).", count);
                });
            };

            // query to get all the friends
            var query = string.Format("SELECT uid,pic_square FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1={0})", "me()");

            // Note: For windows phone 7, make sure to add [assembly: InternalsVisibleTo("Facebook")] if you are using anonymous objects as parameter.
            fb.GetAsync("fql", new { q = query });
        }

       
    }

}
