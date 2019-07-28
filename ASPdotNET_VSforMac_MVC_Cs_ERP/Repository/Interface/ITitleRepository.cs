using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository
{
    public interface ITitleRepository
    {
        Task<Title> GetByIdAsync(int id);
        Task<List<Title>> ListAsync();
        Task AddAsync(Title title);
        Task UpdateAsync(Title title);
        Task DeleteAsync(Title title);
    }
}
