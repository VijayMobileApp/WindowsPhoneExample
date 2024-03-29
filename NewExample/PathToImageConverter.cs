﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.IO;
using System.IO.IsolatedStorage;

namespace NewExample
{
    public class PathToImageConverter : IValueConverter
    {
        public BitmapImage ConvertPathToBitmapImage(string path)
        {
            BitmapImage img = new BitmapImage();
            try
            {
                if (!String.IsNullOrEmpty(path))
                {
                    using (var file = LoadFile(path))
                    {
                        img.SetSource(file);
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return img;
        }

        private Stream LoadFile(string file)
        {
            var ResrouceStream = Application.GetResourceStream(new Uri(file, UriKind.Relative));
            if (ResrouceStream != null)
            {
                Stream myFileStream = ResrouceStream.Stream;
                if (myFileStream.CanRead)
                {
                    StreamReader myStreamReader = new StreamReader(myFileStream);

                    return myStreamReader.BaseStream;
                }
            }
            return null;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage img = new BitmapImage();
            if (value != null)
            {
                img = this.ConvertPathToBitmapImage(value as string);
            }
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
