using Code48Software.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code48Software.Controllers
{
    public class HomeController : Controller
    {
        private _48SoftwareModel db = new _48SoftwareModel();
        public ActionResult Index()
        {
            string ConnStr = ConfigurationManager.ConnectionStrings["Nebula48SoftwareModel"].ConnectionString;
            List<String> TableNames = GetTables(ConnStr);
            return View(TableNames);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static List<string> GetTables(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }
    }
}