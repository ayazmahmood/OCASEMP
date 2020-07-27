using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpWebAPI.Models;
using EmpWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpWebAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]    
    public class EmployeesController : ControllerBase
    {

            private readonly EmpRepository _empr;
            public EmployeesController(EmpRepository empr)
            {
                _empr = empr;
            }

            [HttpGet]                
            public async Task<object> Get()
            {
                var emplist = await _empr.GetEmployees();
            return Ok(emplist);
            }

        [HttpPost]        
        public async Task<object> PostEmployee(Employees emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Employees empobj = new Employees();
            empobj.FirstName = emp.FirstName;
            empobj.LastName = emp.LastName;
            empobj.EmailID = emp.EmailID;
            empobj.Activities = emp.Activities;
            empobj.Comments = emp.Comments;
            var res = await _empr.AddEmployee(empobj);
            return Ok(res);
        }

        //[HttpPost]
        //public async Task<object> Post()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return Ok(null);
        //}


    }

}