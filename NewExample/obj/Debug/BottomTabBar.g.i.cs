﻿#pragma checksum "D:\Vijay\Example\My try\NewExample1\NewExample\BottomTabBar.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C3EE24E3B702F4EA4FF1C065F4EE7000"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace NewExample {
    
    
    public partial class BottomTabBar : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid BottomToolUIContainer;
        
        internal System.Windows.Controls.Button MyBeno;
        
        internal System.Windows.Controls.Button Search;
        
        internal System.Windows.Controls.Button MyBasket;
        
        internal System.Windows.Controls.Button MyInfo;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/NewExample;component/BottomTabBar.xaml", System.UriKind.Relative));
            this.BottomToolUIContainer = ((System.Windows.Controls.Grid)(this.FindName("BottomToolUIContainer")));
            this.MyBeno = ((System.Windows.Controls.Button)(this.FindName("MyBeno")));
            this.Search = ((System.Windows.Controls.Button)(this.FindName("Search")));
            this.MyBasket = ((System.Windows.Controls.Button)(this.FindName("MyBasket")));
            this.MyInfo = ((System.Windows.Controls.Button)(this.FindName("MyInfo")));
        }
    }
}

