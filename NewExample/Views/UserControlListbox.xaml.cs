﻿using System;
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
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class UserControlListbox : PhoneApplicationPage
    {
        public UserControlListbox()
        {
            InitializeComponent();
            UserControlListBox.DataContext = new UserControlListboxViewModel();
        }
    }
}