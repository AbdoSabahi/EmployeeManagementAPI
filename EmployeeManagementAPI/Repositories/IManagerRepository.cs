using EmployeeManagementAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Repositories
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync();
        Task<Manager> GetManagerByIdAsync(int id);
        Task<Manager> AddManagerAsync(Manager manager);
        Task<Manager> UpdateManagerAsync(Manager manager);
        Task<bool> DeleteManagerAsync(int id);
    }
}
