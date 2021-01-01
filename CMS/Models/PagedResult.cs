using System.Collections.Generic;

namespace CMS.Models
{
    public class PagedResult<T> : PagingResultBase
    {
        public IEnumerable<T> Items { set; get; }
    }
}