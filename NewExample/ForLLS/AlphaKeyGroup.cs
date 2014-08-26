
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
namespace NewExample.ForLLS
{

    public class AlphaKeyGroup<T> : List<T>, IList
    {
        public string OwnerImage
        {
            get;
            set;
        }

        public delegate string GetKeyDelegate(T item);


        public string Key { get; set; }


        public bool HasItems
        {
            get
            {
                return this.Count > 0;
            }
        }

        public AlphaKeyGroup(string key)
        {
            //if (AppGlobalConstants.InvitationCheck)
            //{
            //    if (key == "O" || key == "o")
            //        Key = AppResources.Label50431;
            //    else if (key == "I" || key == "i")
            //        Key = AppResources.Label50432;
            //    else
            //        Key = key;
            //}
            //else
            Key = key;

        }

        public override string ToString()
        {
            return Key;
        }

        private static ObservableCollection<AlphaKeyGroup<T>> CreateGroups(string nameList)
        {

            ObservableCollection<AlphaKeyGroup<T>> list = new ObservableCollection<AlphaKeyGroup<T>>();
            foreach (char key in nameList.ToCharArray())
            {
                if (key == '*')
                {
                    list.Add(new AlphaKeyGroup<T>(SortedLocalGrouping.GlobeGroupKey));
                }
                else
                {
                    list.Add(new AlphaKeyGroup<T>((key.ToString().ToUpper())));
                }

            }
            return list;
        }


        public static ObservableCollection<AlphaKeyGroup<T>> CreateGroups(IEnumerable<T> items, CultureInfo ci, GetKeyDelegate getKey, bool sort)
        {
            SortedLocalGrouping sortedLocalGrouping = new SortedLocalGrouping(ci);
            ObservableCollection<AlphaKeyGroup<T>> list = CreateGroups(sortedLocalGrouping.Headings);

            foreach (T item in items)
            {
                int index = 0;
                {
                    string label = getKey(item);
                    index = sortedLocalGrouping.IndexOf(label[0].ToString().ToUpper());
                }
                if (index >= 0 && index < list.Count)
                {
                    string groupCharacter = list[index].Key;
                    list[index].Add(item);
                }
            }

            if (sort)
            {
                foreach (AlphaKeyGroup<T> group in list)
                {
                    group.Sort((c0, c1) => { return ci.CompareInfo.Compare(getKey(c0), getKey(c1)); });
                }
            }
            return list;
        }

    }

}
