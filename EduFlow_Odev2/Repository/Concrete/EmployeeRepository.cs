using EduFlow_Odev2.Base;
using EduFlow_Odev2.Data;
using EduFlow_Odev2.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Data
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext Context) : base(Context)
        {
        }

        public Task<(IEnumerable<Employee> records, int total)> GetPaginationAsync(QueryResource pagination, EmployeeDto filterResource)
        {
            throw new System.NotImplementedException();
        }
        public override async Task<Employee> GetByIdAsync(int id)
        {
            return await Context.Employee.AsSplitQuery().SingleOrDefaultAsync(x => x.EmpID == id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.Employee.CountAsync();
        }
    }
}
