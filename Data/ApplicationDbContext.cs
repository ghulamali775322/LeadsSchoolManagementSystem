using Microsoft.EntityFrameworkCore;
using LeadsSMS.Models;

namespace LeadsSMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<StudentFee> StudentFees { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
    }
}
