using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPdotNET_VSforMac_MVC_Cs_ERP.Models;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int Id);
        Task<List<Employee>> ListAsync();
        Tuple<List<Employee>, int> PageList(int pageindex, int pagesize);
        Task AddAsync(Employee employee);
        Task ModifiedAsync(Employee employee);
        Task RemoveAsync(Employee employee);
    }
}
