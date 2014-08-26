﻿

using System.Linq;
using System.Collections.Generic;
namespace NewExample.ForLLS
{
    public class GroupingLayer<TKey, TElement> : IGrouping<TKey, TElement>
    {

        private readonly IGrouping<TKey, TElement> grouping;

        public GroupingLayer(IGrouping<TKey, TElement> unit)
        {

            grouping = unit;

        }

        public TKey Key
        {

            get { return grouping.Key; }

        }

        public IEnumerator<TElement> GetEnumerator()
        {

            return grouping.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return grouping.GetEnumerator();

        }

    }
}
