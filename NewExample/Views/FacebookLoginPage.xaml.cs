using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Facebook;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class FacebookLoginPage : PhoneApplicationPage
    {
        private const string AppId = "151958794967229";
        private const string ExtendedPermissions = "user_about_me,read_stream,publish_stream,user_birthday";
        private readonly FacebookClient _fb = new FacebookClient();

        FacebookLoginPageViewModel login;
        public FacebookLoginPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(FacebookPage_Loaded);
        }

        void FacebookPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Giving it 2 parameters. The controller where I
            //want the web browser to appear and
            //also reference to the page because
            //only then I can call the Messagebox.show()
            login = new FacebookLoginPageViewModel(ContentPanel, this);
            //loginn = new SignupViewModel();
            // loginn.facebooklog(ContentPanel, this);
        }

        //private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //var loginUrl = GetFacebookLoginUrl(AppId, ExtendedPermissions);
        //    //webBrowser1.Navigate(loginUrl);
        //}

        //private Uri GetFacebookLoginUrl(string appId, string extendedPermissions)
        //{
        //    var parameters = new Dictionary<string, object>();
        //    parameters["client_id"] = appId;
        //    parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
        //    parameters["response_type"] = "token";
        //    parameters["display"] = "touch";

        //    // add the 'scope' only if we have extendedPermissions.
        //    if (!string.IsNullOrEmpty(extendedPermissions))
        //    {
        //        // A comma-delimited list of permissions
        //        parameters["scope"] = extendedPermissions;
        //    }

        //    return _fb.GetLoginUrl(parameters);
        //}

        //private void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    //FacebookOAuthResult oauthResult;
        //    //if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
        //    //{
        //    //    return;
        //    //}

        //    //if (oauthResult.IsSuccess)
        //    //{
        //    //    var accessToken = oauthResult.AccessToken;
        //    //    LoginSucceded(accessToken);
        //    //}
        //    //else
        //    //{
        //    //    // user cancelled
        //    //    MessageBox.Show(oauthResult.ErrorDescription);
        //    //}
        //}

        //private void LoginSucceded(string accessToken)
        //{
        //    var fb = new FacebookClient(accessToken);

        //    fb.GetCompleted += (o, e) =>
        //    {
        //        if (e.Error != null)
        //        {
        //            Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
        //            return;
        //        }

        //        var result = (IDictionary<string, object>)e.GetResultData();
        //        var id = (string)result["id"];

        //        var url = string.Format("/Views/FacebookInfoPage.xaml?access_token={0}&id={1}", accessToken, id);

        //        Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
        //    };

        //    fb.GetAsync("me?fields=id");
        //}
    }
}