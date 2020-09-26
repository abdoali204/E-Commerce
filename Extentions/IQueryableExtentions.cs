using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using E_Commerce.Core.Models;

namespace E_Commerce.Extentions
{
    public static class IQueryableExtentions
    {
        public static IQueryable<Product> ApplyFiltering(this IQueryable<Product> products,ProductQuery queryObj)
        {
            if(!String.IsNullOrWhiteSpace(queryObj.CategoryName))
                products  = products.Where(p => p.Category.Name.ToLower()==queryObj.CategoryName.ToLower());
            if(queryObj.StarRating.HasValue && queryObj.StarRating > -1 && queryObj.StarRating < 6)
                products  = products.Where(p => p.Rating >= queryObj.StarRating);
            return products;
        }
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query,IQueryObject queryObject,Dictionary<string,Expression<Func<T,object>>> columnsMap)
        {
            if(String.IsNullOrWhiteSpace(queryObject.SortBy) || !columnsMap.ContainsKey(queryObject.SortBy))
            {
                return query;
            }
            if(queryObject.IsSortAscending)
                return query.OrderBy(columnsMap[queryObject.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObject.SortBy]);
        }
        public static IQueryable<T> Paging<T>(this IQueryable<T> query,IQueryObject queryObject)
        {
            if(queryObject.Page <= 0)
                queryObject.Page = 1;
            if(queryObject.PageSize <=0)
                queryObject.PageSize = 10;
            return query.Skip((queryObject.Page-1)*queryObject.PageSize).Take(queryObject.PageSize);
        }
    }
}