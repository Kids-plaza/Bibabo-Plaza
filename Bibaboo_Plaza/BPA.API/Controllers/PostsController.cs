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
                var list = _postService.GetAll().Where(x => x.is_deleted == false).ToList();
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
        //[Authorize(Roles = "staff")]
        public IActionResult GetPostById(Guid id)
        {
            try
            {
                var post = _postService.GetById(id);
                if (post == null || post.is_deleted == true)
                {
                    return NotFound("Cannot Find id");
                }
                return Ok(new { value = post });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "staff")]
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
                    title = request.Title,
                    content = request.Content,
                    staff_id = request.StaffId,
                    created_on = DateTime.Now,
                    is_deleted = false,
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
        //[Authorize(Roles = "staff")]
        public IActionResult UpdatePost(Guid id, UpdatePostRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundPost = _postService.GetById(id);
                if (foundPost == null || foundPost.is_deleted == true)
                {
                    return NotFound("Cannot Find Post");
                }
                foundPost.title = request.Title ?? foundPost.title;
                foundPost.content = request.Content ?? foundPost.content;

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "staff")]
        public IActionResult DeletePost(Guid id)
        {
            try
            {
                var foundPost = _postService.GetById(id);
                if (foundPost == null || foundPost.is_deleted == true)
                {
                    return NotFound("Cannot Find Post");
                }
                foundPost.is_deleted = true;
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
