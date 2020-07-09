using Code48Software.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace Code48Software.Helpers
{
    public class PopulateDBHelper
    {
        public List<Employee> FillEmployeeTable(string Path) {
            List<Employee> EmpLst = new List<Employee>();
            using (var reader = new StreamReader(Path))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Employee EmpObj = new Employee();
                    EmpObj.firstName = values[1];
                    EmpObj.lastName = values[2];
                    EmpObj.gender = values[3];
                    EmpObj.email = values[4];//need tobe updated straight up
                    EmpObj.age = values[5]; //Table need to be dropped and recreated
                    EmpObj.birthday = Convert.ToDateTime(values[6]);
                    EmpObj.Active = values[7]; //Convert to Booolean
                    EmpLst.Add(EmpObj);


                }
            }
            return EmpLst;
        }

        public List<Address> FillAddressTable(string Path)
        {
            List<Address> AddrLst = new List<Address>();
            using (var reader = new StreamReader(Path))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Address AddressObj = new Address();
                    AddressObj.EmployeeId = Convert.ToInt32(values[0]); //change ID to String
                    AddressObj.Street = values[1];
                    AddressObj.Postal = values[2];
                    AddressObj.Province = values[3];
                    //AddressObj.City = values[];
                    AddressObj.Longitude = values[5];
                    AddressObj.Latitude = values[6];
                    AddrLst.Add(AddressObj);

                }
            }
            return AddrLst;
        }

        public List<Package> FillPackageTable(string Path)
        {
            List<Package> PackgList = new List<Package>();
            using (var reader = new StreamReader(Path))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Package PackageObj = new Package();
                    PackageObj.EmployeeId = Convert.ToInt32(values[0]); //change ID to String
                    PackageObj.Name = values[1];
                    PackageObj.PackageCost= values[4];
                    PackageObj.ContractStart = Convert.ToDateTime(values[5]);
                    PackageObj.ContractEnd = Convert.ToDateTime(values[3]);
                    PackgList.Add(PackageObj);

                }
            }
            return PackgList;
        }

        public List<Event> FillEventTable(string Path)
        {
            List<Event> PackgList = new List<Event>();
            using (var reader = new StreamReader(Path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Event EventObj = new Event();
                    EventObj.Phone= values[0]; 
                    EventObj.TimeStamp = values[1];
                    EventObj.Date= values[4];
                    EventObj.EventTypeId = Convert.ToInt32(values[5]);
                    EventObj.VendorId = Convert.ToInt32(values[3]);
                    PackgList.Add(EventObj);
                }
            }
            return PackgList;
        }



    }
}