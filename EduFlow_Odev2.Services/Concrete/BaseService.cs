using AutoMapper;
using EduFlow_Odev2.Base;
using EduFlow_Odev2.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Service
{
    public abstract class BaseService<Dto, Entity> : IBaseService<Dto, Entity> where Entity : class
    {

        private readonly IBaseRepository<Entity> baseRepository;
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;


        public BaseService(IBaseRepository<Entity> baseRepository, IMapper mapper, IUnitOfWork unitOfWork) : base()
        {
            this.baseRepository = baseRepository;
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }


        public virtual async Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync()
        {
            // Get list record from DB
            var tempEntity = await baseRepository.GetAllAsync();
            // Mapping Entity to Resource
            var result = Mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(tempEntity);

            return new BaseResponse<IEnumerable<Dto>>(result);
        }

        public virtual async Task<BaseResponse<Dto>> GetByIdAsync(int id)
        {
            var tempEntity = await baseRepository.GetByIdAsync(id);
            // Mapping Entity to Resource
            var result = Mapper.Map<Entity, Dto>(tempEntity);

            return new BaseResponse<Dto>(result);
        }

        public virtual async Task<BaseResponse<Dto>> InsertAsync(Dto insertResource)
        {
            try
            {
                // Mapping Resource to Entity
                var tempEntity = Mapper.Map<Dto, Entity>(insertResource);             

                await baseRepository.InsertAsync(tempEntity);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<Dto>(Mapper.Map<Entity, Dto>(tempEntity));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Saving_Error", ex);
            }
        }

        public virtual async Task<BaseResponse<Dto>> RemoveAsync(int id)
        {
            try
            {
                // Validate Id is existent
                var tempEntity = await baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new BaseResponse<Dto>("Id_NoData");

                baseRepository.RemoveAsync(tempEntity);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<Dto>(Mapper.Map<Entity, Dto>(tempEntity));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Deleting_Error", ex);
            }
        }

        public virtual async Task<BaseResponse<Dto>> UpdateAsync(int id, Dto updateResource)
        {
            try
            {
                // Validate Id is existent
                var tempEntity = await baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new BaseResponse<Dto>("NoData");
                // Update infomation
                Mapper.Map(updateResource, tempEntity);

                await UnitOfWork.CompleteAsync();
                // Mapping
                var resource = Mapper.Map<Entity, Dto>(tempEntity);

                return new BaseResponse<Dto>(resource);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Updating_Error", ex);
            }
        }

     


    }
}
