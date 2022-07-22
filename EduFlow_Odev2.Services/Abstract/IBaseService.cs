using EduFlow_Odev2.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Service
{
    public interface IBaseService<Dto, Entity>
    {
        Task<BaseResponse<Dto>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync();
        Task<BaseResponse<Dto>> InsertAsync(Dto insertResource);
        Task<BaseResponse<Dto>> UpdateAsync(int id, Dto updateResource);
        Task<BaseResponse<Dto>> RemoveAsync(int id);
    }
}
