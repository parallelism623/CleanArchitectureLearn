using CleanArchitecture.Contract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contract.Extensions
{
    public static class SortOrderExtensions 
    {
        public static SortOrder ConvertStringToSortOrder(string? sortOrder)
            => !string.IsNullOrEmpty(sortOrder)
                ? sortOrder.Trim().ToLower().Equals("asc")
                ? SortOrder.Ascending : SortOrder.Descending : SortOrder.Descending;

        public static IDictionary<string, SortOrder> ConvertStringToDictionarySort(string? sortOrder)
        {
            var result = new Dictionary<string, SortOrder>();

            if (!string.IsNullOrEmpty(sortOrder))
            {
                var splitSortOrder = sortOrder.Trim().Split(",");
                if (splitSortOrder.Length > 0) 
                {
                    foreach(var item in splitSortOrder)
                    {
                        if (!item.Contains("-"))
                        {
                            throw new FormatException("Sort condition should be follow by format: Column1-ASC, Column2-DESC....");
                        }
                        var itemSplit = item.Trim().Split("-");
                        var key = ProductExtensions.GetSortProductProperty(itemSplit[0]);
                        var value = ConvertStringToSortOrder(itemSplit[1]);
                        result.Add(key, value);
                    }
                }
            }

            return result;
        }
    }
}
