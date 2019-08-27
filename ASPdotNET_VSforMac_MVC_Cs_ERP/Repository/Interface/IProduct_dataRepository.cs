using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface IProduct_dataRepository
    {
        Task<Product_data> GetByIdAsync(int Id);
        Task<List<Product_data>> ListAsync();
        Tuple<List<Product_data>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Product_data product_Data);
        Task ModifiedAsync(Product_data product_Data);
        Task RemoveAsync(Product_data product_Data);
    }
}
