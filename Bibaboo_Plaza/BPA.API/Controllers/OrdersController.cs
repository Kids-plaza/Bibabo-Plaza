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
using BPA.Service.Services;
using Microsoft.AspNetCore.Authorization;
using BPA.BusinessObject.Dtos.Post;
using BPA.BusinessObject.Enums;
using BPA.BusinessObject.Dtos.Order;

namespace BPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = "Staff")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var list = _orderService.GetAll().Where(x => x.IsDeleted == false).ToList();
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

        [HttpGet("GetAllByStatus")]
        //[Authorize(Roles = "Customer,Staff")]
        public IActionResult GetAllOrdersByStatus(string input)
        {
            try
            {
                var list = _orderService.GetAll().Where(x => x.OrderStatus.ToString() == input && x.IsDeleted == false).ToList();
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

        [HttpGet("GetAllByCustomerId")]
        //[Authorize(Roles = "Customer,Staff")]
        public IActionResult GetAllOrdersByCustomerId(Guid id)
        {
            try
            {
                var list = _orderService.GetAll().Where(x => x.CustomerId == id && x.IsDeleted == false && x.OrderStatus != OrderStatus.InCart).ToList();
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
        //[Authorize(Roles = "Staff,Customer")]
        public IActionResult GetOrderById(Guid id)
        {
            try
            {
                var order = _orderService.GetById(id);
                if (order == null || order.IsDeleted == true)
                {
                    return NotFound("Cannot Find Id");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "Customer")]
        public IActionResult CreateOrder(OrderRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }

                var newOrder = new Order
                {
                    TotalPrice = request.TotalPrice,
                    TotalQuantity = request.TotalQuantity,
                    CustomerId = request.CustomerId,
                    OrderStatus = OrderStatus.InCart,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };
                _orderService.Add(newOrder);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        //[Authorize(Roles = "Customer,Staff")]
        public IActionResult UpdateOrder(Guid id, OrderRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundOrder = _orderService.GetById(id);
                if (foundOrder == null || foundOrder.IsDeleted == true)
                {
                    return NotFound("Cannot Find Order");
                }
                foundOrder.TotalPrice = request.TotalPrice;
                foundOrder.TotalQuantity = request.TotalQuantity;
                foundOrder.CustomerId = request.CustomerId;

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ConfirmOrder/{id}")]
        //[Authorize(Roles = "Customer")]
        public IActionResult ConfirmOrder(Guid id)
        {
            try
            {
                var foundOrder = _orderService.GetById(id);
                if (foundOrder == null || foundOrder.IsDeleted == true)
                {
                    return NotFound("Cannot Find Order");
                }
                switch (foundOrder.OrderStatus)
                {
                    case OrderStatus.InCart:
                        foundOrder.OrderStatus = OrderStatus.Pending;
                        break;
                    default:
                        foundOrder.OrderStatus = foundOrder.OrderStatus;
                        break;
                }
                _orderService.Update(foundOrder);
                return Ok("Change Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeOrderStatus/{id}")]
        //[Authorize(Roles = "Staff")]
        public IActionResult ChangeOrderStatus(Guid id)
        {
            try
            {
                var foundOrder = _orderService.GetById(id);
                if (foundOrder == null || foundOrder.IsDeleted == true)
                {
                    return NotFound("Cannot Find Order");
                }
                switch (foundOrder.OrderStatus)
                {
                    case OrderStatus.Pending:
                        foundOrder.OrderStatus = OrderStatus.Processing;
                        break;
                    case OrderStatus.Processing:
                        foundOrder.OrderStatus = OrderStatus.Completed;
                        break;
                    default:
                        foundOrder.OrderStatus = foundOrder.OrderStatus;
                        break;
                }
                _orderService.Update(foundOrder);
                return Ok("Change Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CancelOrder/{id}")]
        //[Authorize(Roles = "Staff")]
        public IActionResult CancelOrder(Guid id)
        {
            try
            {
                var foundOrder = _orderService.GetById(id);
                if (foundOrder == null || foundOrder.IsDeleted == true)
                {
                    return NotFound("Cannot Find Order");
                }
                switch (foundOrder.OrderStatus)
                {
                    case OrderStatus.Pending:
                        foundOrder.OrderStatus = OrderStatus.Cancelled;
                        break;
                    case OrderStatus.Processing:
                        foundOrder.OrderStatus = OrderStatus.Cancelled;
                        break;
                    default:
                        foundOrder.OrderStatus = foundOrder.OrderStatus;
                        break;
                }
                _orderService.Update(foundOrder);
                return Ok("Cancel Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "Staff")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                var foundOrder = _orderService.GetById(id);
                if (foundOrder == null || foundOrder.IsDeleted == true)
                {
                    return NotFound("Cannot Find Order");
                }
                foundOrder.IsDeleted = true;
                _orderService.Update(foundOrder);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
