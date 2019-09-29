using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface IOrder_detailRepository
    {
        Task<Order_detail> GetByIdAsync(int Id);
        Task<List<Order_detail>> ListAsync();
        Tuple<List<Order_detail>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Order_detail supply);
        Task ModifiedAsync(Order_detail supply);
        Task RemoveAsync(Order_detail supply);
    }
}
