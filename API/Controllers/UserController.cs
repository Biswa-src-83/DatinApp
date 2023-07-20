using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //api/user
    public class UserController : Controller
    {
        public DataContext _dataContext { get; set; }

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            return user;
        }
    }
}