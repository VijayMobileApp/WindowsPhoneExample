
using Microsoft.Phone.Controls;
using NewExample.ViewModel;
using ImageTools;
using ImageTools.IO.Gif;
using System;

namespace NewExample.Views
{
    public partial class GifToPngExample : PhoneApplicationPage
    {
        public GifToPngExample()
        {
            InitializeComponent();
            this.DataContext = new GifToPngExampleViewModel();
            //ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            //ImageGif.Source = new ExtendedImage() { UriSource = new Uri("http://0.tqn.com/d/graphicssoft/1/0/n/p/5/ST_animated_turkey01.gif", UriKind.Absolute) };
            //http://0.tqn.com/d/graphicssoft/1/0/n/p/5/ST_animated_turkey01.gif
        }

    }
}