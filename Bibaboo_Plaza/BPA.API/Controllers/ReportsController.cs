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
using BPA.BusinessObject.Dtos.Post;
using BPA.BusinessObject.Dtos.Report;

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
        //[Authorize(Roles = "Admin")]
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
        //[Authorize(Roles = "Admin")]
        public IActionResult GetReportById(Guid id)
        {
            try
            {
                var report = _reportService.GetById(id);
                if (report == null || report.is_deleted == true )
                {
                    return NotFound("Cannot Find id");
                }
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "Customer")]
        public IActionResult CreateReport(ReportRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }

                var newReport = new Report
                {
                    Content = request.Content,
                    CustomerId = request.CustomerId,
                    created_on = DateTime.Now,
                    is_deleted = false,
                };
                _reportService.Add(newReport);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        //[Authorize(Roles = "Customer")]
        public IActionResult UpdateReport([FromRoute] Guid id, UpdateReportRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundReport = _reportService.GetById(id);
                if (foundReport == null || foundReport.is_deleted == true)
                {
                    return NotFound("Cannot Find Report");
                }
                foundReport.Content = request.Content ?? foundReport.Content;

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteReport(Guid id)
        {
            try
            {
                var foundReport = _reportService.GetById(id);
                if (foundReport == null || foundReport.is_deleted == true)
                {
                    return NotFound("Cannot Find Report");
                }
                foundReport.is_deleted = true;
                _reportService.Update(foundReport);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
