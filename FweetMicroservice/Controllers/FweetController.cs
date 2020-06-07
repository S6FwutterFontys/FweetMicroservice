using System;
using System.Threading.Tasks;
using FweetMicroservice.Entities;
using FweetMicroservice.Models;
using FweetMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace FweetMicroservice.Controllers
{
    [ApiController, Route("[controller]")]
    public class FweetController : ControllerBase
    {
        private readonly IFweetService _service;

        public FweetController(IFweetService service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateFweet(Fweet fweet)
        {
            var fweetIn = new Fweet()
            {
                FweetId = new Guid(),
                UserId = fweet.UserId,
                FweetMessage = fweet.FweetMessage,
                Timestamp = DateTime.Now.ToFileTime()
            };

            try
            {
                await _service.PlaceFweet(fweetIn);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(fweetIn);
        }

        [HttpGet]
        public async Task<IActionResult> GetFweet(Guid fweetId)
        {
            try
            {
                var fweet = await _service.GetFweet(fweetId);
                return Ok(fweet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFweet(Guid fweetId, UpdateFweetModdel updatedFweet)
        {
            try
            {
                return Ok(await _service.UpdateFweet(fweetId, updatedFweet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFweet(Guid userId, Guid fweetId)
        {
            try
            {
                await _service.DeleteFweet(userId, fweetId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}