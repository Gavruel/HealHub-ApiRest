using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;
using HealHub.Domain.Interfaces;
using HealHub.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealHub.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<List<User>> getAllUsers()
        {
            return _service.getAllUsers();
        }

        [HttpPost]
        public Result<User> createUser(User user)
        {
            return _service.createUser(user);
        }

        [HttpPut("update/{id}")]
        public Result<User> updateUser([FromRoute]int id, User user)
        {
            return _service.updateUser(id, user);
        }

        [HttpDelete("delete/{id}")]
        public Result<bool> deleteUser([FromRoute]int id)
        {
            return _service.deleteUser(id);
        }

    }
}
