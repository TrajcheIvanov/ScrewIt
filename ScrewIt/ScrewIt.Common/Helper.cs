using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ScrewIt.Common
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string ContentCreator = "Content Creator";
        public static string CustomerSupport = "Customer Support";
        public static string ProductionManager = "Production Manager";
        public static string SalesManager = "Sales Manager";
        public static string ProductionEmploye = "Production Employe";
        public static string Customer = "Customer";

        public static List<SelectListItem> GetRolesForDropDown()
        {

            return new List<SelectListItem>
            {
                 new SelectListItem{Value=Helper.Admin,Text=Helper.Admin},
                 new SelectListItem{Value=Helper.ContentCreator,Text=Helper.ContentCreator},
                 new SelectListItem{Value=Helper.CustomerSupport,Text=Helper.CustomerSupport},
                 new SelectListItem{Value=Helper.ProductionManager,Text=Helper.ProductionManager},
                 new SelectListItem{Value=Helper.SalesManager,Text=Helper.SalesManager},
                 new SelectListItem{Value=Helper.ProductionEmploye,Text=Helper.ProductionEmploye},
                 new SelectListItem{Value=Helper.Customer,Text=Helper.Customer}
            };

        }
    }
}
