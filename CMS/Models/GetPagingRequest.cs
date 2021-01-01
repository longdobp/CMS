namespace CMS.Models
{
    public class GetPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string Status { get; set; }
    }
}