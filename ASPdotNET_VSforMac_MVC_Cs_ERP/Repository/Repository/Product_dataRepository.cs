using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Repository
{
    public class Product_dataRepository : IProduct_dataRepository
    {
        private ErpContext _context;

        public Product_dataRepository(ErpContext context)
        {
            _context = context;
        }

        public Task<Product_data> GetByIdAsync(int Id)
        {
            return _context.Product_datas.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Product_data>> ListAsync()
        {
            return _context.Product_datas.ToListAsync();
        }

        //分頁查詢
        public Tuple<List<Product_data>, int> PageList(int pageindex, int pagesize)
        {
            var query = _context.Product_datas.Include(supply => supply.Supply).Include(item_no => item_no.Product_item).AsQueryable();

            var count = query.Count();

            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;

            var product_Datas = query.OrderBy(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();

            return new Tuple<List<Product_data>, int>(product_Datas, pagecount);
        }

        public Task AddAsync(Product_data product_Data)
        {
            _context.Product_datas.AddAsync(product_Data);
            return _context.SaveChangesAsync();
        }

        public Task ModifiedAsync(Product_data product_Data)
        {
            _context.Entry(product_Data).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(Product_data product_Data)
        {
            _context.Remove(product_Data);
            return _context.SaveChangesAsync();
        }
    }
}
