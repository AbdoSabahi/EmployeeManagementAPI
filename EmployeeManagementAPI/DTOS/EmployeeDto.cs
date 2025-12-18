namespace EmployeeManagementAPI.DTOS
{
    public class EmployeeDto
    {


        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
    }
}
