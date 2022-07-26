using DependencyInjection.Context;
using DependencyInjection.Interfaces;
using DependencyInjection.Models;
using DependencyInjection.Realisation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        private readonly IEmployee<User> _employee;
        public EmployeeController(IEmployee<User> employee) => _employee = employee;
     

        [HttpGet("get/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var res = await _employee.FullInfo(id);
            if (res != null)
            {
               return Ok(res);
            }
            else
            {
               return BadRequest();
            }
        }


        [HttpPost("add")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var res = await _employee.Add(user);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            var res = await _employee.Update(user);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("delete/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var res = await _employee.Delete(id);
            if (res)
            {
                return Ok("Successfully deleted");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
