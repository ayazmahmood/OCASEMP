using EmpWebAPI.Models;
using EmpWebAPI.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpWebAPI.Repositories
{
    public class EmpRepository : IEmployees
    {
        EmpDBContext _db;
        public EmpRepository(EmpDBContext db)
        {
            _db = db; 
        }

        public async Task<IEnumerable<result>> AddEmployee(Employees emp)
        {
            IEnumerable<result> res = new List<result>(); ;
            try { 
                SqlParameter FirstNameParam = new SqlParameter("@p_FirstName", emp.FirstName);
                SqlParameter LastNameParam = new SqlParameter("@p_LastName",emp.LastName);
                SqlParameter EmailIDParam = new SqlParameter("@p_EmailID", emp.EmailID);
                SqlParameter ActivitiesParam = new SqlParameter("@p_Activities", emp.Activities);
                SqlParameter CommentsParam = new SqlParameter("@p_Comments", emp.Comments);
                //var result = await _db.Set<result>().FromSqlRaw(@"EXEC [dbo].[usp_AddEmp] @p_FirstName, @p_LastName, @p_EmailID, @p_Activities, @p_Comments", FirstNameParam, LastNameParam, EmailIDParam, ActivitiesParam, CommentsParam).AsNoTracking().SingleOrDefaultAsync();
                res = await _db.Set<result>().FromSqlRaw(@"EXEC [dbo].[usp_AddEmp] @p_FirstName, @p_LastName, @p_EmailID, @p_Activities, @p_Comments", FirstNameParam, LastNameParam, EmailIDParam, ActivitiesParam, CommentsParam).AsNoTracking().ToListAsync();
                
                //return result.AsEnumerable();
            }
            catch (Exception e)
            {

            }
                //return res[0].Result;
            return res;
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {
            IEnumerable<Employees> result = new List<Employees>();
            try
            {
                result = await _db.Set<Employees>().FromSqlRaw(@"EXEC [dbo].[usp_GetAllEmp]").AsNoTracking().ToListAsync();
            }
            catch (Exception e) { }
            return result.AsEnumerable();
        }
    }
}
