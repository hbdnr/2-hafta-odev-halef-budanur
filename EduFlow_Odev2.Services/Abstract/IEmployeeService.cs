using EduFlow_Odev2.Base;
using EduFlow_Odev2.Data;
using EduFlow_Odev2.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Service
{
    public interface IEmployeeService : IBaseService<EmployeeDto, Employee>
    {
        Task<PaginationResponse<IEnumerable<EmployeeDto>>> GetPaginationAsync(QueryResource pagination, EmployeeDto filterResource);
    }
}
