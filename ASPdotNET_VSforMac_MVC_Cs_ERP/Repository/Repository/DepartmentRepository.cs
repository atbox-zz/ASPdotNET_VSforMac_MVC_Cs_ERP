using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ErpContext _context;

        public DepartmentRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Department> GetByIdAsync(int Id)
        {
            return _context.Departments.FirstOrDefaultAsync(d => d.Id == Id);
        }

        public Task<List<Department>> ListAsync()
        {
            return _context.Departments.ToListAsync();
        }

        public Task AddAsync(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChangesAsync();
        }

    }
}
