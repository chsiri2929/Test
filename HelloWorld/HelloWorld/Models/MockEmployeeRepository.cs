using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private IEnumerable<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Sireesha" , Email = "s@mail.com", Department = "Software Developer", FavLink = "https://www.youtube.com/watch?v=_5vrfuwhvlQ"},
                new Employee() { Id= 2, Name = "Ravi", Email = "r@mail.com", Department = "Software Engineer", FavLink = "https://www.youtube.com/watch?v=x9Hrn0oNmJM"}
            };

        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }
    }
}
