using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication3.DTO;

namespace WebApplication3.Data_Model
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContextcs _dbContext;
        public EmployeeController(EmployeeDbContextcs dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public IEnumerable<Employee> Get()
        {
            return _dbContext.Employees;
        }


        [HttpGet("{id}")]

        public Employee Get(int id)
        {
            var temp = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                throw new Exception("Employee could not find ");
            }
            return temp;
        }

        [HttpPost]
        public async Task<Employee> Post([FromBody] Employee employee)
        {

            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;


        }

        [HttpPut("{id}")]

        public void put(int id, [FromBody]Employee employee)
        {
            var update_employee = _dbContext.Employees.Find(id);
            if(update_employee == null)
            {
                throw new Exception();
            }
            else
            {
                update_employee.Name = employee.Name;
                update_employee.Location = employee.Location;
                update_employee.Emp_Category = employee.Emp_Category;
                _dbContext.Employees.Update(update_employee);
                _dbContext.SaveChanges();
            }
        }
        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            var del = new Employee();
            del = _dbContext.Employees.Find(id);
            if(del== null)
            {
                throw new Exception();
            }
            else
            {
                _dbContext.Employees.Remove(del);
                _dbContext.SaveChanges();
            }
        }
    }
}
