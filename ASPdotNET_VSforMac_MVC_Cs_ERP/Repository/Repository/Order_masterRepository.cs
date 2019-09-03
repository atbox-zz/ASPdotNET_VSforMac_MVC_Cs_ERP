using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class Order_masterRepository : IOrder_masterRepository
    {
        private ErpContext _context;

        public Order_masterRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Order_master> GetByIdAsync(int Id)
        {
            return _context.Order_masters.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Order_master>> ListAsync()
        {
            return _context.Order_masters.ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Order_master>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Order_masters.Include(custom => custom.Custom).Include(deliver => deliver.Deliver).Include(employee => employee.Employee).AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var order_Masters = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Order_master>, int>(order_Masters, pagecount);
        }

        public Task AddAsync(Order_master order_Master)
        {
            _context.Order_masters.AddAsync(order_Master);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Order_master order_Master)
        {
            _context.Entry(order_Master).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Order_master order_Master)
        {
            _context.Remove(order_Master);
            return _context.SaveChangesAsync();
        }
    }
}
