namespace EmployeeManagementAPI.Entities
{
    public class Manager

    {
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department Department { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
