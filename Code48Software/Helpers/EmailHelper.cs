using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Code48Software.Models;
using Code48Software.Controllers;

namespace Code48Software.Helpers
{
    public class EmailHelper
    {

        private _48SoftwareModel db = new _48SoftwareModel();
        EmployeesController employeeContr = new EmployeesController();
        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void UpdateEmail(String CompanyHost)
        {
            var EmpList = db.Employees.ToList();
            try
            {
                foreach (var emp in EmpList)
                {
                    emp.email = generateNewEmail(emp.email, CompanyHost);
                    employeeContr.Edit(emp);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public string generateNewEmail(String OldEmail, String newHost)
        {
            //example@company.com
            if ((OldEmail.Length != 0 && newHost.Length != 0) && IsValid(OldEmail))
            {
                int indexOfAt = OldEmail.LastIndexOf("@");
                int indexOfFullStop = OldEmail.IndexOf(".");
                String host = OldEmail.Substring(indexOfAt + 1);
                String domain = OldEmail.Substring(indexOfFullStop);
                return OldEmail.Replace(host, newHost) + domain;

            }
            else
            {
                return OldEmail;
            }

        }
    }
}