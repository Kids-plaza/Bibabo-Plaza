using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BPA.BusinessObject.Entities;
using BPA.DAO.Context;
using BPA.Service.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllPosts()
        {
            try
            {
                var list = _postService.GetAll().ToList();
                if (!list.Any())
                {
                    return NotFound("No Data");
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        [Authorize(Roles = "Staff")]
        public IActionResult GetPostById(Guid id)
        {
            try
            {
                var account = _postService.GetById(id);
                if (account == null)
                {
                    return NotFound("Cannot Find Id");
                }
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Staff")]
        public IActionResult CreateFeedback(Post request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                _postService.Add(request);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            var feedback = _postService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _postService.Delete(feedback);

            return Ok("Delete Successfully");
        }
    }
}
