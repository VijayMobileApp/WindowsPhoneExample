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

namespace NewExample.ViewModel
{
    public class IsolatedExample2ViewModel : ReactiveObject
    {
        public static string _folderNameBox;
        public string folderNameBox
        {
            get { return _folderNameBox; }
            set { this.RaiseAndSetIfChanged(x => x.folderNameBox, value); }
        }

        public ReactiveAsyncCommand createButton { get; set; }
        public ReactiveAsyncCommand deleteButton { get; set; }

        IsolatedExample2ViewModel per = new IsolatedExample2ViewModel();
        public IsolatedExample2ViewModel()
        {
            createButton = new ReactiveAsyncCommand();
            createButton.Subscribe(x => {
              
            });
        }

    }
}
