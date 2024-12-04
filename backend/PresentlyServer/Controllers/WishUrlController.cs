using Microsoft.AspNetCore.Mvc;
using PresentlyServer.Dtos;
using PresentlyServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentlyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishUrlController(PresentlyDbContext presentlyDbContext) : ControllerBase
    {
        // GET: api/<WishUrlController>
        [HttpGet("{id}")]
        public IActionResult GetWishUrlData(int id)
        {
            DbWishUrl wishUrl = presentlyDbContext.WishUrls.FirstOrDefault(w => w.Id == id);
            if (wishUrl != null)
            {
                return Ok(wishUrl);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<WishUrlController>/5
        [HttpGet("wish/{wishId}")]
        public IActionResult GetWishesUrls(int userId)
        {
            var wishesUrls = presentlyDbContext.WishUrls.Where(w => w.WishId == userId);
            if (wishesUrls.Any())
            {
                return Ok(wishesUrls);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<WishUrlController>
        [HttpPost]
        public IActionResult Post([FromBody] WishUrlCreate wishUrlInfo)
        {
            DbWishUrl wishUrl = new DbWishUrl
            {
                WishId = wishUrlInfo.WishId,
                Url = wishUrlInfo.Url,
                Price = wishUrlInfo.Price,
            };
            presentlyDbContext.WishUrls.Add(wishUrl);
            presentlyDbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<WishUrlController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WishUrlCreate wishUrlInfo)
        {
            DbWishUrl wishUrl = presentlyDbContext.WishUrls.FirstOrDefault(w => w.Id == id);
            if (wishUrl != null)
            {
                wishUrl.WishId = wishUrlInfo.WishId;
                wishUrl.Url = wishUrlInfo.Url;
                wishUrl.Price = wishUrlInfo.Price;
                presentlyDbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<WishUrlController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DbWishUrl wishUrl = presentlyDbContext.WishUrls.FirstOrDefault(w => w.Id == id);
            if (wishUrl == null)
            {
                return BadRequest();
            }
            else
            {
                presentlyDbContext.Remove(wishUrl);
                presentlyDbContext.SaveChanges();
                return NoContent();
            }
        }
    }
}
