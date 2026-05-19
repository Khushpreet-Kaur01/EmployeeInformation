namespace FinalKhushpreetKaur.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? JobTitle { get; set; }
        public int? DepartmentID { get; set; }

        //Navigation property
        public Department? Department { get; set; }
    }
}
