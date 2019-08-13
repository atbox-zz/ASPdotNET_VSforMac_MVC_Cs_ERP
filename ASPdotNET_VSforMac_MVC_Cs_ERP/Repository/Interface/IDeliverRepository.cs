using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface IDeliverRepository
    {
        Task<Deliver> GetByIdAsync(int Id);
        Task<List<Deliver>> ListAsync();
        Tuple<List<Deliver>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Deliver deliver);
        Task ModifiedAsync(Deliver deliver);
        Task RemoveAsync(Deliver deliver);
    }
}
