using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        private readonly ApplictionDbContext dbContext;

        public Employee(ApplictionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAllEmployee()
        {

            return Ok(dbContext.Employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetEmployeebyeId(Guid id)
        {

            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(addEmployeeDto addEmployeeDto)
        {

            if (addEmployeeDto == null)

            {
                return BadRequest("Invalid Eamployee Data !");
            }


            var employee = new EmployeeAdminPortal.Models.Entities.Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                PhoneNumber = addEmployeeDto.PhoneNumber,
                salary = addEmployeeDto.salary,
            };

            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]

        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, addEmployeeDto addEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }

            employee.Name = addEmployeeDto.Name;
            employee.Email = addEmployeeDto.Email;
            employee.PhoneNumber = addEmployeeDto.PhoneNumber;
            employee.salary = addEmployeeDto.salary;


            dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult deleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok("Employee Deleted Successfully");

        }








    }
}
