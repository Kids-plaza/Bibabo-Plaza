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
using BPA.BusinessObject.Enums;
using BPA.Service.Services;
using BPA.BusinessObject.Dtos.Order;

namespace BPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = "Staff")]
        public IActionResult GetAllOrderDetails()
        {
            try
            {
                var list = _orderDetailService.GetAll().Where(x => x.IsDeleted == false).ToList();
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

        [HttpGet("GetAllByOrderId")]
        //[Authorize(Roles = "Customer,Staff")]
        public IActionResult GetAllOrderDetailsByOrderId(Guid id)
        {
            try
            {
                var list = _orderDetailService.GetAll().Where(x => x.OrderId == id && x.IsDeleted == false).ToList();
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
        public IActionResult GetOrderDetailById(Guid id)
        {
            try
            {
                var orderDetail = _orderDetailService.GetById(id);
                if (orderDetail == null || orderDetail.IsDeleted == true)
                {
                    return NotFound("Cannot Find Id");
                }
                return Ok(orderDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "Customer")]
        public IActionResult CreateOrderDetail(OrderDetailRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }

                var newOrderDetail = new OrderDetail
                {
                    Price = request.Price,
                    Quantity = request.Quantity,
                    OrderId = request.OrderId,
                    ProductId = request.ProductId,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };
                _orderDetailService.Add(newOrderDetail);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        //[Authorize(Roles = "Customer")]
        public IActionResult UpdateOrderDetail(Guid id, UpdateOrderDetailRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundOrderDetail = _orderDetailService.GetById(id);
                if (foundOrderDetail == null || foundOrderDetail.IsDeleted == true)
                {
                    return NotFound("Cannot Find Order");
                }
                foundOrderDetail.Price = request.Price;
                foundOrderDetail.Quantity = request.Quantity;
                foundOrderDetail.ProductId = request.ProductId;

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "Customer")]
        public IActionResult DeleteOrderDetail(Guid id)
        {
            try
            {
                var foundOrderDetail = _orderDetailService.GetById(id);
                if (foundOrderDetail == null || foundOrderDetail.IsDeleted == true)
                {
                    return NotFound("Cannot Find Post");
                }
                foundOrderDetail.IsDeleted = true;
                _orderDetailService.Update(foundOrderDetail);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
