using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VKart.Models;

namespace VKart.Controllers
{
    public class ExamplesController : Controller
    {
      
        public ActionResult General()
        {
            return View();
        }

        private List<Role> LoadRoles(string userName)
        {
            var roles = new List<Role>();
           
            roles.Add(new Role() { RoleId = 1 ,RoleName = "Admin" });
            roles.Add(new Role() { RoleId = 2, RoleName = "Manager" });
            roles.Add(new Role() { RoleId = 3, RoleName = "Supervisior" });
            roles.Add(new Role() { RoleId = 3, RoleName = "Guest" });

            return roles;
        }

        [AllowAnonymous]
        public ActionResult GetRolesByUsername(string userName)
        {
            string results = string.Empty;

            if (!string.IsNullOrEmpty(userName))
            {
                SelectListItem[] items;
                var roles = LoadRoles(userName);
                items = roles.Select(role => new SelectListItem
                {
                    Text = role.RoleName,
                    Value = role.RoleId.ToString()
                }).ToArray();

                results = JsonConvert.SerializeObject(items);
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}