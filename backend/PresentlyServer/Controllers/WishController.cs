using Microsoft.AspNetCore.Mvc;
using PresentlyServer.Dtos;
using PresentlyServer.Models;
using static Azure.Core.HttpHeader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentlyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishController(PresentlyDbContext presentlyDbContext) : ControllerBase
    {
        // GET: api/<WishController>
        [HttpGet("{id}")]
        public IActionResult GetWishData(int id)
        {
            DbWish wish = presentlyDbContext.Wishes.FirstOrDefault(w => w.Id == id);
            if (wish != null)
            {
                return Ok(wish);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<WishController>/5
        [HttpGet("user/{userId}")]
        public IActionResult GetUsersWishes(int userId)
        {
            var usersWishes = presentlyDbContext.Wishes.Where(w => w.UserId == userId);
            if(usersWishes.Any())
            {
                return Ok(usersWishes);
            } else
            {
                return NotFound();
            }
        }

        // POST api/<WishController>
        [HttpPost]
        public IActionResult Post([FromBody] WishCreate wishInfo)
        {
            DbWish wish = new DbWish
            {
                Name = wishInfo.Name,
                Notes = wishInfo.Notes,
                UserId = wishInfo.UserId,
                Bought = wishInfo.Bought,
                Currency = wishInfo.Currency
            };
            presentlyDbContext.Wishes.Add(wish);
            presentlyDbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<WishController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WishCreate wishInfo)
        {
            DbWish wish = presentlyDbContext.Wishes.FirstOrDefault(w => w.Id == id);
            if (wish != null)
            {
                wish.Name = wishInfo.Name;
                wish.Notes = wishInfo.Notes;
                wish.UserId = wishInfo.UserId;
                wish.Bought = wishInfo.Bought;
                wish.Currency = wishInfo.Currency;
                presentlyDbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            } 
        }

        // DELETE api/<WishController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DbWish wish = presentlyDbContext.Wishes.FirstOrDefault(w => w.Id == id);
            if (wish == null)
            {
                return BadRequest();
            }
            else
            {
                presentlyDbContext.Remove(wish);
                presentlyDbContext.SaveChanges();
                return NoContent();
            }
        }
    }
}
