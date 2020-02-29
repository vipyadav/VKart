using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Infragistics.Web.Mvc;
using VKart.Models;

namespace VKart.Controllers
{

    public class InfragisticsGridController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees()
        {
            var empList = new List<Employee>
            {
                new Employee { ID = 1, Name = "Ram", Birthdate = new DateTime(1990, 02, 23), IsTemporary = true, Dept_id = 121 },
                new Employee { ID = 2, Name = "Ojas", Birthdate = new DateTime(1998, 02, 12), IsTemporary = true, Dept_id = 122 },
                new Employee { ID = 3, Name = "Kritvik", Birthdate = new DateTime(1992, 02, 09), IsTemporary = true, Dept_id = 123 },
                new Employee { ID = 4, Name = "Reetika", Birthdate = new DateTime(1987, 02, 14), IsTemporary = true, Dept_id = 124 },
                new Employee { ID = 5, Name = "Ravi", Birthdate = new DateTime(1983, 02, 05), IsTemporary = true, Dept_id = 125 }
            };

            return Json(empList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveData()
        {
            GridModel gridModel = new GridModel();
            List<Transaction<Employee>> transactions = gridModel.LoadTransactions<Employee>(HttpContext.Request.Form["ig_transactions"]);

            foreach (Transaction<Employee> t in transactions)
            {
                //do something.. 
            }

            JsonResult result = new JsonResult();
            Dictionary<string, bool> response = new Dictionary<string, bool>();
            response.Add("Success", true);
            result.Data = response;
            return result;


            //	JsonResult result = new JsonResult();
            //	result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //	result.Data = new { Records = data, TotalRecordsCount = totalCount };
            //	return result;

        }
    }
}