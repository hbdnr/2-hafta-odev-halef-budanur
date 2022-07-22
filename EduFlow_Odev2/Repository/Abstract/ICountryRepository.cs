using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Data
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<IEnumerable<Country>> FindByNameAsync(string filterName);
        Task<int> TotalRecordAsync();
    }
}
