using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Models.Dto;

namespace DemoProject.Repository.Interface
{
    public interface IEmployeeService
    {
        Task  <UserDTO> SignUP(Employee employee);
        Task  <LoginResponseDTO> Login(LoginReqDTO loginReq);

      
    }
}
