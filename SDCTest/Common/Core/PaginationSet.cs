using System.Collections.Generic;
using System.Linq;

namespace SDCTest.Common.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }

        public int Count { get { return (Items != null) ? Items.Count() : 0; } }

        public int TotalPage { set; get; }

        public int TotalRow { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}