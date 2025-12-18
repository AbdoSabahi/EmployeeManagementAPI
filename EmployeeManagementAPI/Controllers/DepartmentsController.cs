using EmployeeManagementAPI.Entities;
using EmployeeManagementAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentsController(IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        // GET: api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentRepo.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        // GET: api/departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _departmentRepo.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        // POST: api/departments
        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            var createdDept = await _departmentRepo.AddDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = createdDept.DepartmentId }, createdDept);
        }

        // PUT: api/departments/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
            if (id != department.DepartmentId) return BadRequest();

            var updatedDept = await _departmentRepo.UpdateDepartmentAsync(department);
            return Ok(updatedDept);
        }

        // DELETE: api/departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentRepo.DeleteDepartmentAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
