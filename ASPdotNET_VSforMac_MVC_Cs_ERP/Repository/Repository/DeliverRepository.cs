using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class DeliverRepository : IDeliverRepository
    {
        private ErpContext _context;

        public DeliverRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Deliver> GetByIdAsync(int Id)
        {
            return _context.Delivers.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Deliver>> ListAsync()
        {
            return _context.Delivers.ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Deliver>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Delivers.AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var delivers = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Deliver>, int>(delivers, pagecount);
        }

        public Task AddAsync(Deliver deliver)
        {
            _context.Delivers.AddAsync(deliver);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Deliver deliver)
        {
            _context.Entry(deliver).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Deliver deliver)
        {
            _context.Remove(deliver);
            return _context.SaveChangesAsync();
        }
    }
}
