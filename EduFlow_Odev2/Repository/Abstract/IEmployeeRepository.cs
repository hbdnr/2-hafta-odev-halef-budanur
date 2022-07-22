using EduFlow_Odev2.Base;
using EduFlow_Odev2.Dto;
using ProteinApi.Base;
using ProteinApi.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Data
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<(IEnumerable<Employee> records, int total)> GetPaginationAsync(QueryResource pagination, EmployeeDto filterResource);
        Task<int> TotalRecordAsync();
    }
}
