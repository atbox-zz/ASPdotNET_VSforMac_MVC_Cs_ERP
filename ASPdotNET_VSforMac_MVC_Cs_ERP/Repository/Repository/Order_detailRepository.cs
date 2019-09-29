using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class Order_detailRepository : IOrder_detailRepository
    {
        private ErpContext _context;

        public Order_detailRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Order_detail> GetByIdAsync(int Id)
        {
            return _context.Order_details.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Order_detail>> ListAsync()
        {
            return _context.Order_details.ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Order_detail>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Order_details.Include(order_master => order_master.Order_master).Include(product_data => product_data.Product_data).AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var order_Details = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Order_detail>, int>(order_Details, pagecount);
        }

        public Task AddAsync(Order_detail order_Detail)
        {
            _context.Order_details.AddAsync(order_Detail);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Order_detail order_Detail)
        {
            _context.Entry(order_Detail).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Order_detail order_Detail)
        {
            _context.Remove(order_Detail);
            return _context.SaveChangesAsync();
        }
    }
}
