using AutoMapper;
using EduFlow_Odev2.Base;
using EduFlow_Odev2.Data;
using EduFlow_Odev2.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Service
{
    public class EmployeeService : BaseService<EmployeeDto, Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository EmployeeRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(EmployeeRepository, mapper, unitOfWork)
        {
            this.EmployeeRepository = EmployeeRepository;
        }

        private readonly IEmployeeRepository EmployeeRepository;


        public override async Task<BaseResponse<EmployeeDto>> InsertAsync(EmployeeDto createPersonResource)
        {
            try
            {
                // Mapping Resource to Person
                var person = Mapper.Map<EmployeeDto, Employee>(createPersonResource);
                //Employee.CreatedAt = DateTime.UtcNow;
                

                await EmployeeRepository.InsertAsync(person);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Employee, EmployeeDto>(person);

                return new BaseResponse<EmployeeDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Person_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<EmployeeDto>> UpdateAsync(int id, EmployeeDto request)
        {
            try
            {
                // Validate Id is existent
                var Employee = await EmployeeRepository.GetByIdAsync(id);
                if (Employee is null)
                {
                    return new BaseResponse<EmployeeDto>("Employee_Id_NoData");
                }

                Employee.EmpName = request.EmpName;

                EmployeeRepository.Update(Employee);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<EmployeeDto>(Mapper.Map<Employee, EmployeeDto>(Employee));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Person_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<EmployeeDto>> GetByIdAsync(int id)
        {
            var person = await EmployeeRepository.GetByIdAsync(id);

            // Mapping
            var EmployeeResource = Mapper.Map<Employee, EmployeeDto>(person);

            // 
            return new BaseResponse<EmployeeDto>(EmployeeResource);
        }

        public Task<PaginationResponse<IEnumerable<EmployeeDto>>> GetPaginationAsync(QueryResource pagination, EmployeeDto filterResource)
        {
            throw new NotImplementedException();
        }

        //public async Task<PaginationResponse<IEnumerable<PersonDto>>> GetPaginationAsync(QueryResource pagination, PersonDto filterResource)
        //{            
        //    var paginationPerson = await personRepository.GetPaginationAsync(pagination, filterResource);

        //    // Mapping
        //    var tempResource = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(paginationPerson.records);

        //    var resource = new PaginationResponse<IEnumerable<PersonDto>>(tempResource);

        //    // Using extension-method for pagination
        //    resource.CreatePaginationResponse(pagination, paginationPerson.total);

        //    return resource;
        //}      


    }
}
