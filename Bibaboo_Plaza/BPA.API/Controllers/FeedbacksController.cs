using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BPA.BusinessObject.Entities;
using BPA.Service.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Authorize(Roles = "Staff")]
        public IActionResult GetAllFeedbacks()
        {
            try
            {
                var list = _feedbackService.GetAll().ToList();
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
        public IActionResult GetFeedbackById(Guid id)
        {
            try
            {
                var account = _feedbackService.GetById(id);
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
        [Authorize(Roles = "Customer")]
        public IActionResult CreateFeedback(Feedback request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                _feedbackService.Add(request);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Staff")]
        public IActionResult DeleteFeedback(Guid id)
        {
            var feedback = _feedbackService.GetById( id);
            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackService.Delete(feedback);

            return Ok("Delete Successfully");
        }
    }
}
