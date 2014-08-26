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
using System.Collections.Generic;

namespace NewExample.ViewModel
{
    public class DictionaryExampleViewModel : ReactiveObject
    {
        public string _BackColor4;
        public string BackColor4
        {
            get { return _BackColor4; }
            set { this.RaiseAndSetIfChanged(x => x.BackColor4, value); }
        }

        public ReactiveAsyncCommand Button1 { get; set; }

        public DictionaryExampleViewModel()
        {
            // Populate example Dictionary
            var dict = new Dictionary<int, bool>();
            var test = new Dictionary<string, string>();
            test.Add("vijay", "8807881602");
            test.Add("Dhas", "9943756999");
            dict.Add(3, true);
            dict.Add(5, false);

            // Get a List of all the Keys
            //List<int> keys = new List<int>(dict.Keys);
            //foreach (int key in keys)
            //{
            //    Console.WriteLine("Keys==>"+key);
            //}
            Console.WriteLine("\nValue==>" + test["vijay"]);
            foreach (KeyValuePair<string, string> author in test)
            {
                Console.WriteLine("Key = {0}, Value = {1}", author.Key, author.Value);
            }
        }
    }
}
