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
using BPA.Service.Services;
using BPA.BusinessObject.Dtos.Feedback;
using BPA.BusinessObject.Dtos.Post;

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

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAllPosts()
        {
            try
            {
                var list = _postService.GetAll().Where(x => x.IsDeleted == false).ToList();
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
        //[Authorize(Roles = "Staff")]
        public IActionResult GetPostById(Guid id)
        {
            try
            {
                var post = _postService.GetById(id);
                if (post == null || post.IsDeleted == true)
                {
                    return NotFound("Cannot Find Id");
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "Staff")]
        public IActionResult CreatePost(PostRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }

                var newPost = new Post
                {
                    Title = request.Title,
                    Content = request.Content,
                    StaffId = request.StaffId,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };
                _postService.Add(newPost);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        //[Authorize(Roles = "Staff")]
        public IActionResult UpdatePost(Guid id, UpdatePostRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundPost = _postService.GetById(id);
                if (foundPost == null || foundPost.IsDeleted == true)
                {
                    return NotFound("Cannot Find Post");
                }
                foundPost.Title = request.Title ?? foundPost.Title;
                foundPost.Content = request.Content ?? foundPost.Content;

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "Staff")]
        public IActionResult DeletePost(Guid id)
        {
            try
            {
                var foundPost = _postService.GetById(id);
                if (foundPost == null || foundPost.IsDeleted == true)
                {
                    return NotFound("Cannot Find Post");
                }
                foundPost.IsDeleted = true;
                _postService.Update(foundPost);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
