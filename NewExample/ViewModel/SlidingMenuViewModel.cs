using System;
using ReactiveUI.Xaml;
using System.Windows;
using ReactiveUI;
namespace NewExample.ViewModel
{
    public class SlidingMenuViewModel
    {
        public ReactiveAsyncCommand profileSettingsButton { get; set; }
        public ReactiveAsyncCommand qrCodeReaderButton { get; set; }
        public ReactiveAsyncCommand myOrderButton { get; set; }
        public ReactiveAsyncCommand myAdvantageButton { get; set; }
        public ReactiveAsyncCommand mySphereButton { get; set; }
        public ReactiveAsyncCommand myPointsButton { get; set; }
        public ReactiveAsyncCommand myBenolaButton { get; set; }
        public ReactiveAsyncCommand myStatementButton { get; set; }
        public ReactiveAsyncCommand myHealthButton { get; set; }
        public ReactiveAsyncCommand myFormsButton { get; set; }
        public ReactiveAsyncCommand settingsButton { get; set; }
        public ReactiveAsyncCommand supportButton { get; set; }
        public ReactiveAsyncCommand signOutButton { get; set; }

        public SlidingMenuViewModel()
        {
            profileSettingsButton = new ReactiveAsyncCommand();
            profileSettingsButton.Subscribe(x =>
            {
                MessageBox.Show("profileSettingsButton 1");
            });

            qrCodeReaderButton = new ReactiveAsyncCommand();
            qrCodeReaderButton.Subscribe(x =>
            {
                //MessageBox.Show("qrCodeReaderButton 2");
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage4.xaml", UriKind.Relative));
            });

            myOrderButton = new ReactiveAsyncCommand();
            myOrderButton.Subscribe(x =>
            {
                MessageBox.Show("myOrderButton 3");
            });


            myAdvantageButton = new ReactiveAsyncCommand();
            myAdvantageButton.Subscribe(x =>
            {
                MessageBox.Show("myAdvantageButton 4");
            });


            mySphereButton = new ReactiveAsyncCommand();
            mySphereButton.Subscribe(x =>
            {
                MessageBox.Show("mySphereButton 5");
            });

            myPointsButton = new ReactiveAsyncCommand();
            myPointsButton.Subscribe(x =>
            {
                MessageBox.Show("myPointsButton 6");
            });


            myBenolaButton = new ReactiveAsyncCommand();
            myBenolaButton.Subscribe(x =>
            {
                MessageBox.Show("myBenolaButton 7");
            });

            myStatementButton = new ReactiveAsyncCommand();
            myStatementButton.Subscribe(x =>
            {
                MessageBox.Show("myStatementButton 8");
            });

            myHealthButton = new ReactiveAsyncCommand();
            myHealthButton.Subscribe(x =>
            {
                MessageBox.Show("myHealthButton 9");
            });

            myFormsButton = new ReactiveAsyncCommand();
            myFormsButton.Subscribe(x =>
            {
                MessageBox.Show("myFormsButton 10");
            });

            settingsButton = new ReactiveAsyncCommand();
            settingsButton.Subscribe(x =>
            {
                MessageBox.Show("settingsButton 11");
            });

            supportButton = new ReactiveAsyncCommand();
            supportButton.Subscribe(x =>
            {
                MessageBox.Show("supportButton 12");
            });


            signOutButton = new ReactiveAsyncCommand();
            signOutButton.Subscribe(x =>
            {
                MessageBox.Show("signOutButton 13");
            });
        }
    }
}
