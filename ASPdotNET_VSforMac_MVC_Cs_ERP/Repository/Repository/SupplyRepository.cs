using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class SupplyRepository : ISupplyRepository
    {
        private ErpContext _context;

        public SupplyRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Supply> GetByIdAsync(int Id)
        {
            return _context.Supplies.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Supply>> ListAsync()
        {
            return _context.Supplies.ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Supply>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Supplies.Include(title => title.Title).AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var supplies = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Supply>, int>(supplies, pagecount);
        }

        public Task AddAsync(Supply supply)
        {
            _context.Supplies.AddAsync(supply);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Supply supply)
        {
            _context.Entry(supply).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Supply supply)
        {
            _context.Remove(supply);
            return _context.SaveChangesAsync();
        }
    }
}
