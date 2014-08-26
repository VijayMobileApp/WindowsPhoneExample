using System;
using ReactiveUI;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewExample.ModelClass
{
    public class Photo : ReactiveObject
    {
        public string _id;
        public string id
        {
            get { return _id; }
            set { this.RaiseAndSetIfChanged(x => x.id, value); }
        }

        public string _photo;
        public string photo
        {
            get { return _photo; }
            set { this.RaiseAndSetIfChanged(x => x.photo, value); }
        }

        public string _thumbnail;
        public string thumbnail
        {
            get { return _thumbnail; }
            set { this.RaiseAndSetIfChanged(x => x.thumbnail, value); }
        }

        public bool _selected;
        public bool selected
        {
            get { return _selected; }
            set { this.RaiseAndSetIfChanged(x => x.selected, value); }
        }

        public Photo()
        {

        }

        public Photo(string photo)
        {
            extracts(photo);
        }

        public static Photo extracts(string photo)
        {
            String[] searchTags = { "PhotoID", "PhotoNormal", "PhotoThumbnail", "Selected" };
            List<String> result = new List<String>();
            XDocument xdoc = XDocument.Parse(photo);
            Photo ph = new Photo();
            XElement idnos = null;
            for (int i = 0; i < searchTags.Length; i++)
            {
                try
                {
                    idnos = xdoc.Descendants()
                        .Where(pp => pp.Name == searchTags[i])
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    idnos = null;
                }
                finally
                {
                    result.Add(((null == idnos) || (null == idnos.Value)) ? "" : idnos.Value);
                }
            }

            ph.id = result.ElementAt(0);
            ph.photo = result.ElementAt(1);
            ph.thumbnail = result.ElementAt(2);
            ph.selected = bool.Parse(result.ElementAt(3));
            return ph;
        }
    }
}
