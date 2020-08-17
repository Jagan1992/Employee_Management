using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
using System.Collections.Generic;


namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private EmployeeManagementEntities employeeDbEntities;

        /// <summary>
        /// 
        /// </summary>
        public HomeController()
        {
            employeeDbEntities = new EmployeeManagementEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public ActionResult SaveEmployee(EmployeeModel employee)
        {
            try
            {
                ModelState.Remove("EmployeeId");

                if (!ModelState.IsValid)
                {
                    var employeeModel = new EmployeeModel()
                    {
                        EmployeeName = employee.EmployeeName,
                        Age = employee.Age,
                        Address = employee.Address,
                        PhoneNumber = employee.PhoneNumber
                    };

                    return View("Index", employeeModel);
                }

                var checkEmployee = employeeDbEntities.EmployeeDetails.SingleOrDefault(m => m.EmployeeId == employee.EmployeeId);

                //Insert.
                if (checkEmployee == null)
                {
                    employeeDbEntities.EmployeeDetails.Add(new EmployeeDetail()
                    {
                        EmployeeName = employee.EmployeeName,
                        Age = employee.Age,
                        Address = employee.Address,
                        PhoneNo = employee.PhoneNumber
                    });
                }
                //Update.
                else
                {
                    checkEmployee.EmployeeName = employee.EmployeeName;
                    checkEmployee.Age = employee.Age;
                    checkEmployee.Address = employee.Address;
                    checkEmployee.PhoneNo = employee.PhoneNumber;
                }

                employeeDbEntities.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}