using EmployeeManagementAPI.Entities;
using EmployeeManagementAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerRepository _managerRepo;

        public ManagersController(IManagerRepository managerRepo)
        {
            _managerRepo = managerRepo;
        }

        // GET: api/managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            var managers = await _managerRepo.GetAllManagersAsync();
            return Ok(managers);
        }

        // GET: api/managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            var manager = await _managerRepo.GetManagerByIdAsync(id);
            if (manager == null) return NotFound();
            return Ok(manager);
        }

        // POST: api/managers
        [HttpPost]
        public async Task<ActionResult<Manager>> CreateManager(Manager manager)
        {
            var createdManager = await _managerRepo.AddManagerAsync(manager);
            return CreatedAtAction(nameof(GetManager), new { id = createdManager.ManagerId }, createdManager);
        }

        // PUT: api/managers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Manager>> UpdateManager(int id, Manager manager)
        {
            if (id != manager.ManagerId) return BadRequest();

            var updatedManager = await _managerRepo.UpdateManagerAsync(manager);
            return Ok(updatedManager);
        }

        // DELETE: api/managers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManager(int id)
        {
            var result = await _managerRepo.DeleteManagerAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
