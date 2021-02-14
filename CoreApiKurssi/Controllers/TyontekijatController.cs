using CoreApiKurssi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiKurssi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TyontekijatController : Controller
    {
        northwindContext nc = new northwindContext();

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //var emp = from e in nc.Employees select e;
            var emp = nc.Employees;
            foreach(var e in emp)
            {
                e.Photo = null;
            }
            return emp.ToArray();
        }


        [HttpGet("{key}")]
        public Object Get(int key)
        {
            var emp = nc.Employees.Find(key);
            if (emp != null) return emp;
            return new { Error = "No record found" };
        }

        [HttpPost]
        public Object PostTyontekija([FromBody] Employee empData)
        {
            //validointi?
            nc.Employees.Add(empData);
            nc.SaveChanges();
            return new { employeeId = empData.EmployeeId };
        }

        [HttpPut("{id}")]
        public dynamic EditTyontekija(int id, [FromBody] Employee empData)
        {
            var emp = nc.Employees.Find(id);

            if (emp is null) return new { Error = "Not found" };
            //alla oleva koodi kirjoittaa kaikki propertiesit yli
            nc.Entry(emp).CurrentValues.SetValues(empData);
            nc.SaveChanges();
            return emp;
        }

        [HttpDelete("{id}")]
        public Object DeleteTyontekija(int id)
        {
            var emp = nc.Employees.Find(id);
            if(emp is null) return new { Error = "Not found" };
            nc.Employees.Remove(emp);
            nc.SaveChanges();
            return new { Delete = "Success" };
        }
    }
}
