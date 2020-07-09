using Code48Software.Helpers;
using Code48Software.Models;
using Code48Software.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Code48Software.Controllers
{
    public class TaskController : Controller
    {

        EmailHelper helper = new EmailHelper();
        private _48SoftwareModel db = new _48SoftwareModel();
        EmployeesController EmpContrObj = new EmployeesController();

        // POST: Task/object
        [HttpPost]
        public ActionResult UpdateTable(string TableName, string FileObject, String CompanyDomain)
        {
            var HardCodeFileEmpPath = @"C:\Users\Guest\Desktop\l\Emloyees.csv";
            PopulateDBHelper PopulDB = new PopulateDBHelper();
            

            try
            {
                if (TableName.Equals("Employees"))
                {
                    //Modify as per emp table
                    List<Employee> Emp = PopulDB.FillEmployeeTable(HardCodeFileEmpPath);
                    foreach (var EmpRow in Emp)
                    {
                        EmpContrObj.Create(EmpRow);
                    }
                }
                else if (TableName.Equals(""))
                {
                    ////Modify as per vendor table
                }
            }
            catch (Exception ex)
            {

            }
            return View(); // I would creates modals to inform the user about the results
        }
        // POST: Task/object
        [HttpPost]
        public ActionResult UpdateCompanyDomain(String CompanyDomain)
        {

            //NB : This approach would very slow if we have millions of users that have aleady changed their Domains
            List<Employee> AllEmp = db.Employees.ToList<Employee>();
                foreach (var row  in AllEmp)
                {
                    row.email = helper.generateNewEmail(row.email ,CompanyDomain);
                    db.Entry(row).State = EntityState.Modified;
                    db.SaveChanges();
            }
            
            return View(); // I would creates modals to inform the user about the results
        }
    }
}