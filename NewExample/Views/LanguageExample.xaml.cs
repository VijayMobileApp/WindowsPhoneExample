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
using System.Globalization;

namespace NewExample.Views
{
    public partial class LanguageExample : PhoneApplicationPage
    {
        public string currentCulture = "";
        public LanguageExample()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Tese 2==> " + CultureInfo.CurrentCulture.EnglishName);
            //Console.WriteLine("Tese 3==> " + System.Threading.Thread.CurrentThread.CurrentCulture);
            //Console.WriteLine("Tese 4==> " + CultureInfo.CurrentCulture);

           // Console.WriteLine("Try==> " + CultureInfo.CurrentCulture.Name);
            //Console.WriteLine("Test 1==> " + CultureInfo.CurrentUICulture.EnglishName);

            //My try It is working
            currentCulture = CultureInfo.CurrentUICulture.EnglishName;
            string[] values = currentCulture.Split('(').Select(sValue => sValue.Trim()).ToArray();
            Console.WriteLine("Value 1==> " + values.ElementAt(0));


            //Got form Stack Overflow. It is also working
            var culture = CultureInfo.CurrentCulture;
            if (!culture.IsNeutralCulture)
                culture = culture.Parent;
            Console.WriteLine("New Culture Name==> "+culture.EnglishName);
            
            
        }
    }
}