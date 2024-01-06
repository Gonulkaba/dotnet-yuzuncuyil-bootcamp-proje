using AutoMapper;
using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication;
using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Core.Repositories;
using DotnetYuzuncuYilBootcamp.Core.Services;
using DotnetYuzuncuYilBootcamp.Core.UnitOfWorks;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
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
            var employee = _employeeRepository.Where(x => x.UserName == userName && x.Password == passHashed).FirstOrDefault();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }
    }
}
