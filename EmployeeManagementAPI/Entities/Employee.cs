namespace EmployeeManagementAPI.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        // Foreign Keys
        public int DepartmentId { get; set; }
        public int ManagerId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public Manager Manager { get; set; }
    }
}
