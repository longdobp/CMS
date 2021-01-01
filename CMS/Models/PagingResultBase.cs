using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class PagingResultBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRows { get; set; }

        public int TotalPages
        {
            get
            {
                var pageCount = (double)TotalRows / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}