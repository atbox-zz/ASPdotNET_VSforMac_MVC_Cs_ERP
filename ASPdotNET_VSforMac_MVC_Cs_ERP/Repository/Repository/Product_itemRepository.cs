using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class Product_itemRepository : IProduct_itemRepository
    {
        private ErpContext _context;

        public Product_itemRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Product_item> GetByIdAsync(int Id)
        {
            return _context.Product_items.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Product_item>> ListAsync()
        {
            return _context.Product_items.ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Product_item>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Product_items.AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var product_Items = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Product_item>, int>(product_Items, pagecount);
        }

        public Task AddAsync(Product_item product_Item)
        {
            _context.Product_items.AddAsync(product_Item);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Product_item product_Item)
        {
            _context.Entry(product_Item).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Product_item product_Item)
        {
            _context.Remove(product_Item);
            return _context.SaveChangesAsync();
        }
    }
}
