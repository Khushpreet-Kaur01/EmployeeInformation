using FinalKhushpreetKaur.Data;
using Microsoft.EntityFrameworkCore;
using FinalKhushpreetKaur.Models;

namespace FinalKhushpreetKaur.Services
{
    public class EmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        // METHOD TO GET ALL DEPARTMENTS
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync(string? searchKeyword = null)
        {
            //get all employees
            var employees= _context.Employees
                                   .Include(e => e.Department)
                                   .AsQueryable();

            //get employees by name
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                employees = employees.Where(p => p.EmployeeName != null && p.EmployeeName.Contains(searchKeyword));
            }
            return await employees.ToListAsync();
        }

        //get employees by their department
        public async Task<List<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            var employees = _context.Employees
                                   .Include(e => e.Department)
                                   .AsQueryable();

            if (departmentId > 0)
            {
                employees = employees.Where(e => e.DepartmentID == departmentId);
            }

            return await employees.ToListAsync();
        }
    }
}
