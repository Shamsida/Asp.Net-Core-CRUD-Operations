using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Models.Dto;
using DemoProject.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost("Signup")]
        public async Task <IActionResult> SignUp(Employee employee)
        {
            var emp = await employeeService.SignUP(employee);
            if(emp == null)
            {
                return BadRequest();
            }
            return Ok(emp);
        }
        [HttpPost("Login")]
        public async Task <ActionResult> Login(LoginReqDTO login)
        {
            var emp = await employeeService.Login(login);
            if(emp == null)
            {
                return BadRequest("Inavlid Credential");
            }
            return Ok(emp);
        }




        //private readonly DataContext _dataContext;
        //private string secretkey;

        //public EmployeeController(DataContext dataContext,IConfiguration configuration)
        //{
        //    _dataContext = dataContext;
        //    this.secretkey = configuration.GetValue<string>("Jwt:Key");
        //}

        //[HttpPost("Signup")]
        //public async Task<IActionResult> SignUp(Employee employee)
        //{
        //    if (employee == null)
        //    {
        //        return BadRequest();
        //    }
        //    _dataContext.Employees.Add(employee);
        //    _dataContext.SaveChanges();
        //    return Ok(employee);
        //}
        //[HttpPost]
        //public async Task<ActionResult<LoginResponseDTO>> Login(LoginReqDTO loginReqDTO)
        //{
        //    if (loginReqDTO == null)
        //    {
        //        return BadRequest("Invalid Enrty");
        //    };
        //    var user = _dataContext.Employees.FirstOrDefault(e=>e.Email== loginReqDTO.Email&&e.password==loginReqDTO.Password);
        //    if(user == null)
        //    {
        //        return BadRequest("Username and password didn't match");
        //    }
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var token = Encoding.ASCII.GetBytes(secretkey);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Email, user.Email),
                    

        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new(new SymmetricSecurityKey(token), SecurityAlgorithms.HmacSha256)
        //    };
        //    var jwttoken = tokenHandler.CreateToken(tokenDescriptor);
        //    LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
        //    {
        //        employee = user,
        //        Token = tokenHandler.WriteToken(jwttoken)

        //    };
        //    return Ok(loginResponseDTO);
        //}
    }
}
