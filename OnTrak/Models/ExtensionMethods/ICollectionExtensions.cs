using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.ExtensionMethods
{
    public static class ICollectionExtensions
    {
        public static IEnumerable<SelectListItem> BAreaToSelectListItem<T>(this ICollection<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("BodyAreaId"),
                       Selected = item.GetPropertyValue("BodyAreaId").Equals(selectedValue.ToString())
                   };
        }


        public static IEnumerable<SelectListItem> BPartToSelectListItem<T>(this ICollection<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("BodyPartId"),
                       Selected = item.GetPropertyValue("BodyPartId").Equals(selectedValue.ToString())
                   };
        }
        public static IEnumerable<SelectListItem> MuscleToSelectListItem<T>(this ICollection<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("MuscleId"),
                       Selected = item.GetPropertyValue("MuscleId").Equals(selectedValue.ToString())
                   };
        }
    }
}
