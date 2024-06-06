using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        static string newConectionstrin = "Data Source=DESKTOP-1AJ32P2;Initial Catalog=NORTHWND;Integrated Security=True;";
        NORTHWNDDataContext NORTHWNDDataContext = new NORTHWNDDataContext(newConectionstrin);

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = NORTHWNDDataContext.Employees.ToList();
            List<EmployeeDTO> employeSmallList = new List<EmployeeDTO>();

            foreach (Employee reserv in employees)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO()
                {
                    EmployeeId = reserv.EmployeeID,
                    FirstName = reserv.FirstName,
                    LastName = reserv.LastName,
                };
                employeSmallList.Add(employeeDTO);
            }

            return View(employeSmallList);
        }

        public ActionResult Details(int id)
        {
            List<Employee> employees = NORTHWNDDataContext.Employees.ToList();
            EmployeeDetailsDTO employeDetails = new EmployeeDetailsDTO();

            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == id)
                {
                    employeDetails.EmployeeId = employee.EmployeeID;
                    employeDetails.FirstName = employee.FirstName;
                    employeDetails.LastName = employee.LastName;
                    employeDetails.Title = employee.Title;
                    employeDetails.TitleOfCourtesy = employee.TitleOfCourtesy;
                    employeDetails.Address = employee.Address;
                    employeDetails.City = employee.City;
                }
            }

            return View(employeDetails);
        }
        
        public ActionResult Delete(int id)
        {
            List<Employee> employees = NORTHWNDDataContext.Employees.ToList();

            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == id)
                {
                    NORTHWNDDataContext.Employees.DeleteOnSubmit(employee);
                    NORTHWNDDataContext.SubmitChanges();
                }
            }

            return View();
        }
        
        public ActionResult Edit(int id)
        {
            List<Employee> employees = NORTHWNDDataContext.Employees.ToList();
            EmployeeDetailsDTO employeeEditeRezerv = new EmployeeDetailsDTO();

            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == id)
                {
                    employeeEditeRezerv.EmployeeId = employee.EmployeeID;
                    employeeEditeRezerv.FirstName = employee.FirstName;
                    employeeEditeRezerv.LastName = employee.LastName;
                    employeeEditeRezerv.Address = employee.Address;
                    employeeEditeRezerv.TitleOfCourtesy = employee.TitleOfCourtesy;
                    employeeEditeRezerv.City = employee.City;
                    employeeEditeRezerv.Title = employee.TitleOfCourtesy;
                }
            }

            return View(employeeEditeRezerv);
        }

        public ActionResult SaveEdite(EmployeeDetailsDTO employeeDTO)
        {
            List<Employee> employees = NORTHWNDDataContext.Employees.ToList();

            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == employeeDTO.EmployeeId)
                {
                    employee.FirstName = employeeDTO.FirstName;
                    employee.LastName = employeeDTO.LastName;
                    employee.Address = employeeDTO.Address;
                    employee.TitleOfCourtesy = employeeDTO.TitleOfCourtesy;
                    employee.City = employeeDTO.City;
                    employee.Title = employeeDTO.Title;

                    NORTHWNDDataContext.SubmitChanges();
                }
            }

            return View(employeeDTO);
        }
        
        public ActionResult Create()
        {
            EmployeeCreateDTO employeeCreate = new EmployeeCreateDTO();

            return View(employeeCreate);
        }

        public ActionResult CreateNew(EmployeeCreateDTO newEmployee)
        {
            var employee = new Employee();

            employee.FirstName = newEmployee.FirstName; 
            employee.LastName = newEmployee.LastName;
            employee.Address = newEmployee.Address;
            employee.Title = newEmployee.Title;
            employee.TitleOfCourtesy = newEmployee.TitleOfCourtesy;
            employee.City = newEmployee.City;

            NORTHWNDDataContext.Employees.InsertOnSubmit(employee);

            NORTHWNDDataContext.SubmitChanges();

            return View();
        }
        
    }

}
