using CrudAPI8.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Reflection.Metadata.Ecma335;

namespace CrudAPI8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEmployeeDetails()
        {
           return Ok (_context.Employees.ToList()); 
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employee)
        {
            Employee employee1 = new Employee()
            {
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Gender = employee.Gender,
                PhoneNumber = employee.PhoneNumber,
                Country = employee.Country,
                State = employee.State,
            };
            _context.Employees.Add(employee1);
            _context.SaveChanges(); 
            return Ok(employee1);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeDetailsById(int id)
        {
            var data = _context.Employees.Find(id);
            if(data is null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee(int id,EmployeeDTO employeeDto)
        {
            var employee1  = _context.Employees.Find(id);   
            if(employee1 is null)
            {
                return NotFound();
            }
            employee1.Name = employeeDto.Name;
            employee1.Age = employeeDto.Age;
            employee1.Email = employeeDto.Email;
            employee1.Gender = employeeDto.Gender;
            employee1.PhoneNumber = employeeDto.PhoneNumber;
            employee1.Country = employeeDto.Country;
            employee1.State = employeeDto.State;
            _context.SaveChanges();
            return Ok(employee1);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployeeDetails(int id)
        {
            var data = _context.Employees.Find(id);
            if(data is null)
            {
                return NotFound();
            }
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _context.Employees.Find(id);
            if (data is null)
            {
                return NotFound();
            }
            _context.Employees.ToList();
            return Ok(data);
        }
    }
}
