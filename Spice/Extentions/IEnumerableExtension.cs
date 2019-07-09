using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Spice.Extentions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectValue.ToString())
                   };
        }
    }
}