using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface IProduct_itemRepository
    {
        Task<Product_item> GetByIdAsync(int Id);
        Task<List<Product_item>> ListAsync();
        Tuple<List<Product_item>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Product_item product_Item);
        Task ModifiedAsync(Product_item product_Item);
        Task RemoveAsync(Product_item product_Item);
    }
}
