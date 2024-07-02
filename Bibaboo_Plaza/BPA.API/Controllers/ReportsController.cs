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
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllReports()
        {
            try
            {
                var list = _reportService.GetAll().ToList();
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
        [Authorize(Roles = "Admin")]
        public IActionResult GetReportById(Guid id)
        {
            try
            {
                var account = _reportService.GetById(id);
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
        [AllowAnonymous]
        public IActionResult CreateReport(Report request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                _reportService.Add(request);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteReport(Guid id)
        {
            var feedback = _reportService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _reportService.Delete(feedback);

            return Ok("Delete Successfully");
        }
    }
}
