using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _context;

        public ManagerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manager>> GetAllManagersAsync()
        {
            return await _context.Managers
                                 .Include(m => m.Department)
                                 .Include(m => m.Employees)
                                 .ToListAsync();
        }

        public async Task<Manager> GetManagerByIdAsync(int id)
        {
            return await _context.Managers
                                 .Include(m => m.Department)
                                 .Include(m => m.Employees)
                                 .FirstOrDefaultAsync(m => m.ManagerId == id);
        }

        public async Task<Manager> AddManagerAsync(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
            return manager;
        }

        public async Task<Manager> UpdateManagerAsync(Manager manager)
        {
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();
            return manager;
        }

        public async Task<bool> DeleteManagerAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null) return false;

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
