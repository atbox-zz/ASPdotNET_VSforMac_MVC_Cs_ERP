using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface IOrder_masterRepository
    {
        Task<Order_master> GetByIdAsync(int Id);
        Task<List<Order_master>> ListAsync();
        Tuple<List<Order_master>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Order_master order_Master);
        Task ModifiedAsync(Order_master order_Master);
        Task RemoveAsync(Order_master order_Master);
    }
}
