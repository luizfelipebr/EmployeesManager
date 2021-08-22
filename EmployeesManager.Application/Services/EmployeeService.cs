using AutoMapper;
using EmployeesManager.Domain.Contracts.Employees;
using EmployeesManager.Domain.Entities.Employees;
using EmployeesManager.Domain.Exceptions;
using EmployeesManager.Domain.Interfaces.Repositories;
using EmployeesManager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IAccountsService _accountsServices;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(
            IAccountsService accountsService,
            IEmployeeRepository employeeRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _accountsServices = accountsService;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> CreateEmployee(EmployeePostRequest request)
        {
            if (string.IsNullOrEmpty(request.FirstName))
                throw new BusinessException("The FirstName field cannot be null", "FirstName");

            if (string.IsNullOrEmpty(request.LastName))
                throw new BusinessException("The LastName field cannot be null", "LastName");

            var entity = _mapper.Map<Employee>(request);
            await _employeeRepository.Add(entity);
            _unitOfWork.Commit();

            //TODO: To create the user
            //return _mapper.Map<EmployeeResponse>(entity);

            throw new NotImplementedException();
        }

        public async Task<EmployeeResponse> UpdateEmployee(Guid id, EmployeePutRequest request)
        {
            var entity = await _employeeRepository.GetById(id);
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.PlateNumber = request.PlateNumber > 0 ? request.PlateNumber : entity.PlateNumber;
            entity.LeaderId = request.LeaderId;

            //TODO: To implement rules
            //await _employeeRepository.Update(entity);
            //_unitOfWork.Commit();
            //return _mapper.Map<EmployeeResponse>(entity);

            throw new NotImplementedException();
        }

        public List<EmployeeResponse> GetAllEmployees(EmployeeRequestFilter filter)
        {
            IList<Employee> result;
            if (filter.LeaderId.HasValue)
            {
                result = _employeeRepository.GetAllEmployeesByLeader(filter.LeaderId.Value);
            }
            else
            {
                result = _employeeRepository.GetAll().GetAwaiter().GetResult();
            }
            var response = _mapper.Map<List<EmployeeResponse>>(result);
            return response;
        }

        public bool DeleteEmployee(Guid id)
        {
            _employeeRepository.Delete(id);
            return _unitOfWork.Commit();
        }
    }
}
