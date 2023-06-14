using AutoMapper;
using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Models.Dto;
using DemoProject.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoProject.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private string secretkey;

        public EmployeeService(DataContext dataContext, IConfiguration configuration,IMapper mapper)
        {
            _dataContext = dataContext;
            this.secretkey = configuration.GetValue<string>("Jwt:Key");
            _mapper = mapper;
        }

        public async Task<LoginResponseDTO> Login(LoginReqDTO loginReq)
        {
            try
            {
                if (loginReq == null)
                {
                    throw new Exception("Invalid Enrty");
                };
                var user = _dataContext.Employees.FirstOrDefault(e => e.Email == loginReq.Email && e.password == loginReq.Password);
                if (user == null)
                {
                    throw new Exception("Invalid user name or password");
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = Encoding.ASCII.GetBytes(secretkey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, user.Email),


                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new(new SymmetricSecurityKey(token), SecurityAlgorithms.HmacSha256)
                };
                var jwttoken = tokenHandler.CreateToken(tokenDescriptor);
                LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
                {
                    employee = user,
                    Token = tokenHandler.WriteToken(jwttoken)

                };
                return loginResponseDTO;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<UserDTO> SignUP(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new Exception("Invalid entry");
                }
                _dataContext.Employees.Add(employee);
                await _dataContext.SaveChangesAsync();
                var empDto = _mapper.Map<UserDTO>(employee);
                return empDto;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
