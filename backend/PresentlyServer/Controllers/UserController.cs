using Microsoft.AspNetCore.Mvc;
using PresentlyServer.Dtos;
using PresentlyServer.Models;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentlyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(PresentlyDbContext presentlyDbContext) : ControllerBase
    {

        // GET: api/<UserController>
        [HttpGet("{id}")]
        public IActionResult GetUserData(int id)
        {
            DbUser user = presentlyDbContext.Users.FirstOrDefault(u => u.Id == id);
            if(user != null) {
                return Ok(user);
            } else {
                return BadRequest();
            } 
        }

        //INSERT
        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserRegistrate userInfo)
        {
            if(presentlyDbContext.Users.FirstOrDefault(u => u.Username == userInfo.Username) != null || presentlyDbContext.Users.FirstOrDefault(u => u.Email == userInfo.Email) != null)
            {
                return BadRequest();
            } else
            {
                userInfo.SetPassword(userInfo.Password);
                DbUser user = new DbUser
                {
                    Username = userInfo.Username,
                    Email = userInfo.Email,
                    Birthday = userInfo.Birthday,
                    Salt = userInfo.GetSalt(),
                    Hash = userInfo.GetHash(),
                };
                presentlyDbContext.Users.Add(user);
                presentlyDbContext.SaveChanges();
                return Ok();
            }
        }

        //UPDATE
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserRegistrate userInfo)
        {
            var otherUsers = presentlyDbContext.Users.Where(u => u.Id != id);
            if(otherUsers.Any(u => u.Username == userInfo.Username) || otherUsers.Any(u => u.Email == userInfo.Email))
            {
                return BadRequest();
            } else
            {
                DbUser user = presentlyDbContext.Users.FirstOrDefault(u => u.Id == id);
                user.Username = userInfo.Username;
                user.Email = userInfo.Email;
                user.Birthday = userInfo.Birthday;
               // user.Salt = userInfo.Salt;
               // user.Hash = userInfo.Hash;
                presentlyDbContext.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DbUser user = presentlyDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return BadRequest();
            } else
            {
                presentlyDbContext.Remove(user);
                presentlyDbContext.SaveChanges();
                return NoContent();
            }
        }
    }
}