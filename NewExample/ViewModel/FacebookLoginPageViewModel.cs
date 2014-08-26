using System;
using Microsoft.Phone.Controls;
using System.Windows.Controls;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using Facebook;

namespace NewExample.ViewModel
{
    public class FacebookLoginPageViewModel
    {
        private static WebBrowser _webBrowser;
        private Page _page;
        private const string ExtendedPermissions = "user_about_me,read_stream,publish_stream,user_birthday,offline_access,email";
        private readonly FacebookClient _fb = new FacebookClient();
        private const string AppId = "151958794967229";
        private static string access_tocken;
        Uri url;
        public FacebookLoginPageViewModel(Panel container, Page page)
        {
            _page = page;
            _webBrowser = new WebBrowser();

            var loginUrl = GetFacebookLoginUrl(AppId, ExtendedPermissions);
            url = loginUrl;
            container.Children.Add(_webBrowser);
            _webBrowser.Navigated += webBrowser_Navigated;
            _webBrowser.Navigate(loginUrl);
        }

        private Uri GetFacebookLoginUrl(string appId, string extendedPermissions)
        {
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = appId;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["response_type"] = "token";
            parameters["display"] = "touch";

            // add the 'scope' only if we have extendedPermissions.
            if (!string.IsNullOrEmpty(extendedPermissions))
            {
                // A comma-delimited list of permissions
                parameters["scope"] = extendedPermissions;
            }
            return _fb.GetLoginUrl(parameters);
        }

        void webBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }

            if (oauthResult.IsSuccess)
            {
                var accessToken = oauthResult.AccessToken;
                access_tocken = accessToken;
                LoginSucceded(accessToken);
            }
            else
            {
                // user cancelled
                MessageBox.Show(oauthResult.ErrorDescription);
            }
        }

        private void LoginSucceded(string accessToken)
        {
            var fb = new FacebookClient(accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show(e.Error.Message);
                        return;
                    });
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                var id = (string)result["id"];

                var url = string.Format("/Views/FacebookInfoPage.xaml?access_token={0}&id={1}", accessToken, id);
                var rootFrame = (App.Current as App).RootFrame;
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                   {
                       rootFrame.Navigate(new Uri(url, UriKind.Relative));
                   });
            };

            fb.GetAsync("me?fields=id");
        }

        public static void logoutSession()
        {
            _webBrowser.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(CheckForout);
            string logouturl = "https://www.facebook.com/connect/login_success.html";
            string newURL = string.Format("https://www.facebook.com/logout.php?next={0}&access_token={1}", logouturl, access_tocken);
            _webBrowser.Navigate(new Uri(newURL));
            _webBrowser.Visibility = Visibility.Visible;

        }

        public static void CheckForout(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

            string fbLogoutDoc = _webBrowser.SaveToString();

            Regex regex = new Regex
            ("\\<a href=\\\"/logout(.*)\\\".*data-sigil=\\\"logout\\\"");
            MatchCollection matches = regex.Matches(fbLogoutDoc);
            if (matches.Count > 0)
            {
                string finalLogout = string.Format("http://m.facebook.com/logout{0}",
                    matches[0].Groups[1].ToString().Replace("amp;", ""));
                _webBrowser.Navigate(new Uri(finalLogout));
            }
        }

        private void clearCookiesFromBrowser()
        {
            LoadCompletedEventHandler loadCompleted = null;
            loadCompleted = (sender, e) =>
            {
                if (
                    _webBrowser.SaveToString().Contains("logout_form"))
                {
                    _webBrowser.InvokeScript("eval", "document.forms['logout_form'].submit();");
                    //AppSettings.FacebookAccessKey = null;
                    //RaisePropertyChanged("LoggedIntoFacebook");
                    _webBrowser.Visibility = Visibility.Collapsed;
                    _webBrowser.LoadCompleted -= loadCompleted;
                }
            };

            _webBrowser.LoadCompleted += loadCompleted;
            _webBrowser.Navigate(new Uri("https://www.facebook.com/logout.php"));
        }
    }
}
