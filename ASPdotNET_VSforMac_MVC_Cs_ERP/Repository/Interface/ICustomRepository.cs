using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface ICustomRepository
    {
        Task<Custom> GetByIdAsync(int Id);
        Task<List<Custom>> ListAsync();
        Tuple<List<Custom>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Custom custom);
        Task ModifiedAsync(Custom custom);
        Task RemoveAsync(Custom custom);
    }
}
