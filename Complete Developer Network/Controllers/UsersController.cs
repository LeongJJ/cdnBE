using Complete_Developer_Network.Data;
using Complete_Developer_Network.Models;
using Complete_Developer_Network.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Complete_Developer_Network.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.Users.ToList();

            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(Models.AddUserDto addUserDto)
        {
            var userEntity = new User()
            {
                Username = addUserDto.Username,
                Name = addUserDto.Name,
                Email = addUserDto.Email,
                Phone = addUserDto.Phone,
                Skillsets = addUserDto.Skillsets,
                Hobby = addUserDto.Hobby
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);
        }

        [HttpPatch]
        [Route("UpdateUser/{id:guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            { 
                return NotFound();
            }

            user.Username = updateUserDto.Username;
            user.Name = updateUserDto.Name;
            user.Email = updateUserDto.Email;
            user.Phone = updateUserDto.Phone;
            user.Skillsets = updateUserDto.Skillsets;
            user.Hobby = updateUserDto.Hobby;

            dbContext.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        [Route("DeleteUser/{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok(user);
        }
    }
}
