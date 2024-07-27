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
using BPA.BusinessObject.Dtos.Account;
using BPA.BusinessObject.Enums;
using BPA.BusinessObject.Dtos.Brand;
using Microsoft.IdentityModel.Tokens;

namespace BPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        public BrandsController(IBrandService brandService, IProductService productService)
        {
            _brandService = brandService;
            _productService = productService;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAllBrands()
        {
            try
            {
                var list = _brandService.GetAll().Where(x => x.is_deleted == false).ToList();
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
        public IActionResult GetBrandById(Guid id)
        {
            try
            {
                var brand = _brandService.GetById(id);
                if (brand == null || brand.is_deleted == true)
                {
                    return NotFound("Cannot Find id");
                }
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search")]
        [AllowAnonymous]
        public IActionResult SearchBrandByName(string input)
        {
            try
            {
                var listByName = _brandService.GetAll().Where(x => x.BrandName!.Contains(input, StringComparison.OrdinalIgnoreCase) && x.is_deleted == false).ToList();
                IList<Brand> list = new List<Brand>();
                if (!listByName.Any())
                {
                    return NotFound("Cannot Find Brand");
                }
                else if (listByName.Any())
                {
                    list = listByName;
                }
                else
                {
                    list = _brandService.GetAll().Where(x => x.is_deleted == false).ToList();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "staff")]
        public IActionResult CreateBrand(BrandRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var listByName = _brandService.GetAll().Where(x => x.BrandName!.Equals(request.BrandName) && x.is_deleted == false);
                if (listByName.Any())
                {
                    return BadRequest("Brand With Name " + request.BrandName + " Already Exist");
                }

                var newBrand = new Brand
                {
                    BrandName = request.BrandName,
                    BrandAddress = request.BrandAddress,
                    BrandPhone = request.BrandPhone,
                    Description = request.Description,
                    created_on = DateTime.Now,
                    is_deleted = false,
                };
                _brandService.Add(newBrand);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        //[Authorize(Roles = "staff")]
        public IActionResult UpdateBrand(Guid id, BrandRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundBrand = _brandService.GetById(id);
                if (foundBrand == null || foundBrand.is_deleted == true)
                {
                    return NotFound("Cannot Find Brand");
                }

                var existingBrandByName = _brandService.GetAll().FirstOrDefault(x => x.BrandName == request.BrandName && x.is_deleted == false);
                if (request.BrandName != null && !request.BrandName.Equals(foundBrand.BrandName))
                {
                    if (existingBrandByName != null)
                        return BadRequest("Name Is Already Used");
                    foundBrand.BrandName = request.BrandName;
                }
                foundBrand.Description = request.Description ?? foundBrand.Description;
                foundBrand.BrandAddress = request.BrandAddress ?? foundBrand.BrandAddress;
                foundBrand.BrandPhone = request.BrandPhone ?? foundBrand.BrandPhone;

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "staff")]
        public IActionResult DeleteBrand(Guid id)
        {
            try
            {
                var foundBrand = _brandService.GetById(id);
                var hasProduct = _productService.GetAll().Where(x => x.BrandId == id && x.is_deleted == false);
                if (foundBrand == null || foundBrand.is_deleted == true)
                {
                    return NotFound("Cannot Find Brand");
                }
                if (hasProduct.IsNullOrEmpty())
                {
                    foundBrand.is_deleted = true;
                    _brandService.Update(foundBrand);
                    return Ok("Delete Successfully");
                }
                return BadRequest("Cannot Delete Brand");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }   
}
