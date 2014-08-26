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
    public class RoughPageViewModel : ReactiveObject
    {
        public static double _rectWidth;
        public double rectWidth
          {
              get { return _rectWidth; }
              set { this.RaiseAndSetIfChanged(x => x.rectWidth, value); }
          }

        public static double _widthText;
        public double widthText
        {
            get { return _widthText; }
            set { this.RaiseAndSetIfChanged(x => x.widthText, value); }
        }

        public static double _floatText;
        public double floatText
        {
            get { return _floatText; }
            set { this.RaiseAndSetIfChanged(x => x.floatText, value); }
        }

        public static string _floatResult;
        public string floatResult
        {
            get { return _floatResult; }
            set { this.RaiseAndSetIfChanged(x => x.floatResult, value); }
        }

       
        public static string _splitText;
        public string splitText
        {
            get { return _splitText; }
            set { this.RaiseAndSetIfChanged(x => x.splitText, value); }
        }


        public ReactiveAsyncCommand withCalculate { get; set; } 
        public ReactiveAsyncCommand floatCalculate { get; set; }
        public ReactiveAsyncCommand blinkingOff { get; set; }
        public ReactiveAsyncCommand paddingDisable { get; set; }
        public ReactiveAsyncCommand splitButton { get; set; } 
        
        
        

        
        public RoughPageViewModel()
        {
            withCalculate = new ReactiveAsyncCommand();
            withCalculate.Subscribe(x=>
            {
                double width = widthText;
                double totWidth = 210;
                rectWidth = widthText * (totWidth / 100);
            });

            floatCalculate = new ReactiveAsyncCommand();
            floatCalculate.Subscribe(x => {
                floatResult = floatText.ToString("#.0");
                Console.Out.WriteLine(floatText.ToString("#.000"));
            
            });

           
            blinkingOff = new ReactiveAsyncCommand();
            blinkingOff.Subscribe(x =>
            {
                MessageBox.Show("You have clicked the blinking removed button");

            });

            paddingDisable = new ReactiveAsyncCommand();
            paddingDisable.Subscribe(x =>
            {
                MessageBox.Show("You have clicked the padding Removed button");

            });

            splitButton = new ReactiveAsyncCommand();
            splitButton.Subscribe(x => {
                if (!string.IsNullOrEmpty(splitText))
                {
                    string str = splitText;
                    string[] nameParts = str.Split(',');
                    string firstName = nameParts[0];
                    string lastName = nameParts[1];
                    MessageBox.Show(firstName+"  And  "+lastName);
                }
            });
        }
    }
}
