using E_Commerce.Extentions;

namespace E_Commerce.Controllers.Resources
{
    public class ProductQueryResource : IQueryObject
    {
        public int? StarRating {get;set;}
        public string ProductName {get;set;}
        public string CategoryName {get;set;}
        public string SortBy {get;set;}
        public bool IsSortAscending {get;set;}
        public int Page {get;set;}
        public int PageSize {get;set;}
    }
}