using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int Id);
        Task<List<Department>> ListAsync();
        Task AddAsync(Department department);
        Task ModifiedAsync(Department department);
        Task RemoveAsync(Department department);
    }
}
