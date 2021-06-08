using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    //when we inherit from another c# class, we get all of its attributes, methods, and properties available in the derived class
    public class UsersController : BaseApiController
    {   
        //Using dependency injection to inject our data context into usercontroller
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        
        //We could of used a List<>, but it offers too many features that is not needed. We just need a simple list to return to the user. So IEnumerable fits that need. 
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        // api/users/3
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}