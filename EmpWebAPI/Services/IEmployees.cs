using EmpWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpWebAPI.Services
{
    public interface IEmployees
    {
        Task<IEnumerable<Employees>> GetEmployees();
        //Task<int> AddEmployee(Employees emp);
        Task<IEnumerable<result>> AddEmployee(Employees emp);

    }
}
