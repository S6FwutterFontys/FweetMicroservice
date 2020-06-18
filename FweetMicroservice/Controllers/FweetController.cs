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
        public async Task<IActionResult> CreateFweet(CreateFweetModel fweet)
        {
            try
            {
                return Ok(await _service.PlaceFweet(fweet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet ( "User/{userId}")]
        public async Task<IActionResult> GetFweetsByUserId(Guid userId)
        {
            try
            {
                return Ok(await _service.GetFweetsByUserId(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet ( "{fweetId}")]
        public async Task<IActionResult> GetFweet(Guid fweetId)
        {
            try
            {
                return Ok(await _service.GetFweet(fweetId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet ("")]
        public async Task<IActionResult> GetAllFweets()
        {
            try
            {
                return Ok( await _service.GetAllFweets());
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
                return BadRequest(e.Message);
            }
        }
    }
}