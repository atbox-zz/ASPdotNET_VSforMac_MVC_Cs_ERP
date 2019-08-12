using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface ISupplyRepository
    {
        Task<Supply> GetByIdAsync(int Id);
        Task<List<Supply>> ListAsync();
        Tuple<List<Supply>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Supply supply);
        Task ModifiedAsync(Supply supply);
        Task RemoveAsync(Supply supply);
    }
}
