using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ErpContext _context;

        public EmployeeRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Employee> GetByIdAsync(int Id)
        {
            return _context.Employees.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public Task<List<Employee>> ListAsync()
        {
            return _context.Employees.Include(title => title.Title).Include(department => department.Department).ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Employee>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Employees.Include(title => title.Title).Include(department => department.Department).AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var employees = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Employee>, int>(employees, pagecount);
        }

        public Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Employee employee)
        {
            _context.Remove(employee);
            return _context.SaveChangesAsync();
        }

    }
}
