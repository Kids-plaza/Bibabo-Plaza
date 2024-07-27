using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BPA.BusinessObject.Entities;
using BPA.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using BPA.Service.Services;
using BPA.BusinessObject.Dtos.Feedback;
using BPA.BusinessObject.Dtos.Brand;

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

        [HttpGet("GetAll")]
        //[Authorize(Roles = "staff")]
        public IActionResult GetAllFeedbacks()
        {
            try
            {
                var list = _feedbackService.GetAll().Where(x => x.is_deleted == false).ToList();
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

        [HttpGet("GetAllByProduct")]
        //[Authorize(Roles = "Customer,staff")]
        public IActionResult GetAllFeedbacksByProductId(Guid id)
        {
            try
            {
                var list = _feedbackService.GetAll().Where(x => x.ProductId == id && x.is_deleted == false).ToList();
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
        public IActionResult GetFeedbackById(Guid id)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                if (feedback == null || feedback.is_deleted == true)
                {
                    return NotFound("Cannot Find id");
                }
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "Customer")]
        public IActionResult CreateFeedback(FeedBackRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }

                var newFeedback = new Feedback
                {
                    Content = request.Content,
                    ProductId = request.ProductId,
                    CustomerId = request.CustomerId,
                    created_on = DateTime.Now,
                    is_deleted = false,
                };
                _feedbackService.Add(newFeedback);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        //[Authorize(Roles = "Customer")]
        public IActionResult UpdateFeedBack(Guid id, UpdateFeedbackRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundFeedback = _feedbackService.GetById(id);
                if (foundFeedback == null || foundFeedback.is_deleted == true)
                {
                    return NotFound("Cannot Find Feedback");
                }
                foundFeedback.Content = request.Content ?? foundFeedback.Content;

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "Customer,staff")]
        public IActionResult DeleteFeedback(Guid id)
        {
            try
            {
                var foundFeedback = _feedbackService.GetById(id);
                if (foundFeedback == null || foundFeedback.is_deleted == true)
                {
                    return NotFound("Cannot Find FeedBack");
                }
                foundFeedback.is_deleted = true;
                _feedbackService.Update(foundFeedback);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
