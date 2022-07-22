using AutoMapper;
using EduFlow_Odev2.Base;
using EduFlow_Odev2.Data;
using EduFlow_Odev2.Dto;
using System;
using System.Threading.Tasks;


namespace EduFlow_Odev2.Service
{
    public class CountryService : BaseService<CountryDto, Country>, ICountryService
    {
        public CountryService(ICountryRepository CountryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(CountryRepository, mapper, unitOfWork)
        {
            this.CountryRepository = CountryRepository;
        }

        private readonly ICountryRepository CountryRepository;


        public override async Task<BaseResponse<CountryDto>> InsertAsync(CountryDto createCountryResource)
        {
            try
            {
                // Mapping Resource to Country
                var Country = Mapper.Map<CountryDto, Country>(createCountryResource);

                await CountryRepository.InsertAsync(Country);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Country, CountryDto>(Country);

                return new BaseResponse<CountryDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Country_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<CountryDto>> UpdateAsync(int id, CountryDto request)
        {
            try
            {
                // Validate Id is existent
                var Country = await CountryRepository.GetByIdAsync(id);
                if (Country is null)
                {
                    return new BaseResponse<CountryDto>("Country_Id_NoData");
                }

                Country.CountryName = request.CountryName;
                Country.Continent = request.Continent;
                Country.Currency = request.Currency;

                CountryRepository.Update(Country);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<CountryDto>(Mapper.Map<Country, CountryDto>(Country));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Country_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<CountryDto>> GetByIdAsync(int id)
        {
            //  return await base.GetByIdAsync(id);
            var Country = await CountryRepository.GetByIdAsync(id);

            // Mapping
            var CountryResource = Mapper.Map<Country, CountryDto>(Country);

            return new BaseResponse<CountryDto>(CountryResource);
        }

    }
}
