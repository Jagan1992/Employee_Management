using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.WebApiControllers
{
    public class EmployeeController : ApiController
    {

        /// <summary>
        /// Default Constructor.
        /// </summary>
        private EmployeeController()
        {

        }

        #region methods
        /// <summary>
        /// Method for Saving the EmployeeDetails.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [Route("api/Employee/SaveEmployee")]
        [HttpPost]
        public HttpResponseMessage saveEmployee(EmployeeModel employee)
        {
            try
            {
                using (var dbEmployeeEntities = new EmployeeManagementEntities())
                {
                    var checkEmployeeExists = dbEmployeeEntities.EmployeeDetails.Where(m => m.EmployeeId == employee.EmployeeId);

                    dbEmployeeEntities.EmployeeDetails.Add(new EmployeeDetail()
                    {
                        EmployeeName = employee.EmployeeName,
                        Age = employee.Age,
                        Address = employee.Address,
                        PhoneNo = employee.PhoneNumber
                    });

                    //Saving the EmployeeDetails.
                    dbEmployeeEntities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.InnerException.Message);
            }
        }

        /// <summary>
        /// Method for Getting the EmployeeDetails.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Employee/GetEmployeeDetails")]
        public HttpResponseMessage getEmployeeDetails()
        {
            try
            {
                using (var dbEmployeeEntities = new EmployeeManagementEntities())
                {
                    var employeeDetails = dbEmployeeEntities.EmployeeDetails.ToList();

                    return Request.CreateResponse(HttpStatusCode.OK, employeeDetails);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Method For Updaing the EmployeeDetails.
        /// </summary>
        /// <returns></returns>
        [Route("api/Employee/UpdateEmployee/{EmployeeId}")]
        [HttpPut]
        public HttpResponseMessage updateEmployeeDetails(int EmployeeId, EmployeeModel employee)
        {
            try
            {
                using (var dbEmployeeEntities = new EmployeeManagementEntities())
                {
                    var checkEmployee = dbEmployeeEntities.EmployeeDetails.Where(m => m.EmployeeId == EmployeeId).SingleOrDefault();

                    if (checkEmployee == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                    }

                    if (checkEmployee != null)
                    {
                        checkEmployee.EmployeeId = EmployeeId;
                        checkEmployee.EmployeeName = employee.EmployeeName;
                        checkEmployee.Age = employee.Age;
                        checkEmployee.Address = employee.Address;
                        checkEmployee.PhoneNo = employee.PhoneNumber;
                    }

                    dbEmployeeEntities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, checkEmployee);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Method for Deleting the Employee.
        /// </summary>
        /// <param name="id"></param> 
        /// <returns></returns>
        [Route("api/Employee/DeleteEmployee/{EmployeeId}")]
        [HttpDelete]
        public HttpResponseMessage deleteEmployeeDetails(int EmployeeId)
        {
            try
            {
                using (var dbEmployeeEntities = new EmployeeManagementEntities())
                {
                    var checkEmployee = dbEmployeeEntities.EmployeeDetails.Where(m => m.EmployeeId == EmployeeId).SingleOrDefault();

                    if (checkEmployee == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                    }

                    dbEmployeeEntities.EmployeeDetails.Remove(checkEmployee);

                    dbEmployeeEntities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, checkEmployee);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}
