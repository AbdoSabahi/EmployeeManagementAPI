namespace EmployeeManagementAPI.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }

        // Navigation Properties
        public Manager Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
