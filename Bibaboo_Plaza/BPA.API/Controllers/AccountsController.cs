using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BPA.BusinessObject.Entities;
using BPA.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using BPA.BusinessObject.Dtos.Account;
using BPA.BusinessObject.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BPA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _config;
        public AccountsController(IAccountService accountService, IConfiguration config)
        {
            _accountService = accountService;
            _config = config;
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public IActionResult SignIn(LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var account = _accountService.GetAccountByEmailAndPassword(request);
                if (account == null)
                {
                    return Unauthorized("Invalid Email Or Password");
                }
                if (account.Status == AccountStatus.Banned)
                {
                    return Unauthorized("Your Account is Inactived");
                }
                var jwt = GenerateJWT(account);
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public IActionResult SignUp(SignUpRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                if (!request.Password!.Equals(request.ConfirmPassword))
                {
                    return BadRequest("Confirm password do not match password");
                }
                var listByEmail = _accountService.GetAll().Where(x => x.Email!.Equals(request.Email) && x.IsDeleted == false);
                if (listByEmail.Any())
                {
                    return BadRequest("Account With Email " + request.Email + " Already Exist");
                }

                var newAccount = new Account
                {
                    Email = request.Email,
                    Password = request.Password,
                    FullName = request.FullName,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    Role = RoleType.Customer,
                    Status = AccountStatus.Active,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };
                _accountService.Add(newAccount);
                return Ok("Sign Up Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var list = _accountService.GetAll().Where(x => x.IsDeleted == false).ToList();
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
        public IActionResult GetAccountById(Guid id)
        {
            try
            {
                var account = _accountService.GetById(id);
                if (account == null || account.IsDeleted == true)
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

        [HttpGet("Search")]
        //[Authorize(Roles = "Admin")]
        public IActionResult SearchAccountByEmailOrName(string input)
        {
            try
            {
                var listByEmail = _accountService.GetAll().Where(x => x.Email!.Contains(input, StringComparison.OrdinalIgnoreCase) && x.IsDeleted == false).ToList();
                var listByName = _accountService.GetAll().Where(x => x.FullName!.Contains(input, StringComparison.OrdinalIgnoreCase) && x.IsDeleted == false).ToList();
                IList<Account> list = new List<Account>();
                if (!listByEmail.Any() && !listByName.Any())
                {
                    return NotFound("Cannot Find Account");
                }
                else if (listByEmail.Any())
                {
                    list = listByEmail;
                }
                else if (listByName.Any())
                {
                    list = listByName;
                }
                else 
                {
                    list = _accountService.GetAll().Where(x => x.IsDeleted == false).ToList();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "Admin")]
        public IActionResult CreateAccount(CreateAccountRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var listByEmail = _accountService.GetAll().Where(x => x.Email!.Equals(request.Email) && x.IsDeleted == false);
                if (listByEmail.Any())
                {
                    return BadRequest("Account With Email " + request.Email + " Already Exist");
                }

                var newAccount = new Account
                {
                    Email = request.Email,
                    Password = request.Password,
                    FullName = request.FullName,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    Role = request.Role,
                    Status = AccountStatus.Active,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };
                _accountService.Add(newAccount);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SelfUpdate/{id}")]
        //[Authorize(Roles = "Admin,Customer,Staff")]
        public IActionResult UpdateAccount(Guid id, UpdateAccountRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundAccount = _accountService.GetById(id);
                if (foundAccount == null || foundAccount.IsDeleted == true)
                {
                    return NotFound("Cannot Find Account");
                }

                var existingAccountByEmail = _accountService.GetAll().FirstOrDefault(x => x.Email!.Equals(request.Email) && x.IsDeleted == false);

                if (request.Email != null && !request.Email.Equals(foundAccount.Email))
                {
                    if (existingAccountByEmail != null)
                        return BadRequest("Email Is Already Used");
                    foundAccount.Email = request.Email;
                }
                foundAccount.FullName = request.FullName ?? foundAccount.FullName;
                foundAccount.Address = request.Address ?? foundAccount.Address;
                foundAccount.Password = request.Password ?? foundAccount.Password;
                foundAccount.PhoneNumber = request.PhoneNumber ?? foundAccount.PhoneNumber;

                _accountService.Update(foundAccount);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AdminUpdate/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult UpdateAccountWithRoleAdmin(Guid id, AdminUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundAccount = _accountService.GetById(id);
                if (foundAccount == null || foundAccount.IsDeleted == true)
                {
                    return NotFound("Cannot Find Account");
                }

                var existingAccountByEmail = _accountService.GetAll().FirstOrDefault(x => x.Email == request.Email && x.IsDeleted == false);
                if (request.Email != null && !request.Email.Equals(foundAccount.Email))
                {
                    if (existingAccountByEmail != null)
                        return BadRequest("Email Is Already Used");
                    foundAccount.Email = request.Email;
                }  
                foundAccount.FullName = request.FullName ?? foundAccount.FullName;
                foundAccount.Address = request.Address ?? foundAccount.Address;
                foundAccount.PhoneNumber = request.PhoneNumber ?? foundAccount.PhoneNumber;
                foundAccount.Role = request.Role;
                _accountService.Update(foundAccount);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeStatus/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult ChangeStatus(Guid id)
        {
            try
            {
                var foundAccount = _accountService.GetById(id);
                if (foundAccount == null || foundAccount.IsDeleted == true)
                {
                    return NotFound("Cannot Find Account");
                }
                if (foundAccount.Role == RoleType.Admin)
                {
                    return BadRequest("User With Admin Role Cannot Be Inactived");
                }
                switch (foundAccount.Status)
                {
                    case AccountStatus.Active:
                        foundAccount.Status = AccountStatus.Banned;
                        break;
                    case AccountStatus.Banned:
                        foundAccount.Status = AccountStatus.Active;
                        break;
                    default:
                        foundAccount.Status = AccountStatus.Active;
                        break;
                }
                _accountService.Update(foundAccount);

                return Ok("Change Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteAccount(Guid id)
        {
            try
            {
                var foundAccount = _accountService.GetById(id);
                if (foundAccount == null || foundAccount.IsDeleted == true)
                {
                    return NotFound("Cannot Find Account");
                }
                if (foundAccount.Role == RoleType.Admin)
                {
                    return BadRequest("User With Admin Role Cannot Be Deleted");
                }
                foundAccount.IsDeleted = true;
                _accountService.Update(foundAccount);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateJWT(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              new Claim[]
              {
                  new(ClaimTypes.Email, account.Email),
                  new(ClaimTypes.Role, account.Role.ToString()),
                  new("Id", account.Id.ToString()),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
