using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class CustomRepository : ICustomRepository
    {
        private ErpContext _context;

        public CustomRepository(ErpContext context)
        {
            _context = context;
        }


        public Task<Custom> GetByIdAsync(int Id)
        {
            return _context.Customs.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Custom>> ListAsync()
        {
            return _context.Customs.ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Custom>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Customs.Include(title => title.Title).AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var customs = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Custom>, int>(customs, pagecount);
        }

        public Task AddAsync(Custom custom)
        {
            _context.Customs.AddAsync(custom);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Custom custom)
        {
            _context.Entry(custom).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Custom custom)
        {
            _context.Remove(custom);
            return _context.SaveChangesAsync();
        }
    }
}
