using AutoMapper;
using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication;
using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Core.Repositories;
using DotnetYuzuncuYilBootcamp.Core.Services;
using DotnetYuzuncuYilBootcamp.Core.UnitOfWorks;
using DotnetYuzuncuYilBootcamp.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Service.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public EmployeeService(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtAuthenticationManager= jwtAuthenticationManager;
        } 
        public string GeneratePasswordHash(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName)) 
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            byte[] employeeBytes = Encoding.UTF8.GetBytes(userName);
            string employeeByteString = Convert.ToBase64String(employeeBytes);
            string smallByteString = $"{employeeByteString.Take(2)}.{employeeByteString.Reverse().Take(2)}";
            byte[] smallBytes = Encoding.UTF8.GetBytes(smallByteString);
            byte[] passBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashed = this.GenerateSaltedHash(passBytes, smallBytes);

            return Convert.ToBase64String(hashed);
        }
        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt) 
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public EmployeeDto FindUser(string userName, string password)  
        {
            string passHashed = GeneratePasswordHash(userName, password);
            var employee = _repository.Where(x => x.UserName == userName && x.Password == passHashed).FirstOrDefault();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }


        public Employee UpdateEmployee(Employee employee, AuthRequestDto authRequestDto)
        {
            employee.UserName = authRequestDto.UserName;
            employee.Email = authRequestDto.Email;
            employee.Position = authRequestDto.Position;
            employee.Password = GeneratePasswordHash(authRequestDto.UserName, authRequestDto.Password);
            return employee;
        }

        public Employee SignUp(AuthRequestDto authDto)  
        {

            #region Password'un hash'li halini veri tabanına göndermek için güncelleme yap
            var passwordHash =GeneratePasswordHash(authDto.UserName, authDto.Password);
            #endregion

            var employee =AddAsync(new Employee
            {
                Email = authDto.Email,
                Password = passwordHash,
                UserName = authDto.UserName,
                Position = authDto.Position
            });
            return employee.Result;
        }

        public AuthResponseDto Login(AuthLoginDto request)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            EmployeeDto employee = FindUser(request.UserName, request.Password);
            responseDto = _jwtAuthenticationManager.Authenticate(request.UserName, request.Password);
            responseDto.Employee = employee;

            return responseDto;
        }
    }
}
