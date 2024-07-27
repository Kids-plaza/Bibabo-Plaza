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
                    return Unauthorized("Invalid email Or password");
                }
                if (account.status == AccountStatus.Banned)
                {
                    return Unauthorized("Your Account is Inactived");
                }
                var jwt = GenerateJWT(account);
                return Ok(new { token = jwt});
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
                var listByEmail = _accountService.GetAll().Where(x => x.email!.Equals(request.Email) && x.is_deleted == false);
                if (listByEmail.Any())
                {
                    return BadRequest("Account With email " + request.Email + " Already Exist");
                }

                var newAccount = new Account
                {
                    email = request.Email,
                    password = request.Password,
                    fullname = request.FullName,
                    phone_number = request.PhoneNumber,
                    address = request.Address,
                    role = RoleType.Customer,
                    status = AccountStatus.Active,
                    created_on = DateTime.Now,
                    is_deleted = false,
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
                var list = _accountService.GetAll().Where(x => x.is_deleted == false).ToList();
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
                if (account == null || account.is_deleted == true)
                {
                    return NotFound("Cannot Find id");
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
                var listByEmail = _accountService.GetAll().Where(x => x.email!.Contains(input, StringComparison.OrdinalIgnoreCase) && x.is_deleted == false).ToList();
                var listByName = _accountService.GetAll().Where(x => x.fullname!.Contains(input, StringComparison.OrdinalIgnoreCase) && x.is_deleted == false).ToList();
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
                    list = _accountService.GetAll().Where(x => x.is_deleted == false).ToList();
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
                var listByEmail = _accountService.GetAll().Where(x => x.email!.Equals(request.Email) && x.is_deleted == false);
                if (listByEmail.Any())
                {
                    return BadRequest("Account With email " + request.Email + " Already Exist");
                }

                var newAccount = new Account
                {
                    email = request.Email,
                    password = request.Password,
                    fullname = request.FullName,
                    phone_number = request.PhoneNumber,
                    address = request.Address,
                    role = request.Role,
                    status = AccountStatus.Active,
                    created_on = DateTime.Now,
                    is_deleted = false,
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
        //[Authorize(Roles = "Admin,Customer,staff")]
        public IActionResult UpdateAccount(Guid id, UpdateAccountRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Input");
                }
                var foundAccount = _accountService.GetById(id);
                if (foundAccount == null || foundAccount.is_deleted == true)
                {
                    return NotFound("Cannot Find Account");
                }

                var existingAccountByEmail = _accountService.GetAll().FirstOrDefault(x => x.email!.Equals(request.Email) && x.is_deleted == false);

                if (request.Email != null && !request.Email.Equals(foundAccount.email))
                {
                    if (existingAccountByEmail != null)
                        return BadRequest("email Is Already Used");
                    foundAccount.email = request.Email;
                }
                foundAccount.fullname = request.FullName ?? foundAccount.fullname;
                foundAccount.address = request.Address ?? foundAccount.address;
                foundAccount.password = request.Password ?? foundAccount.password;
                foundAccount.phone_number = request.PhoneNumber ?? foundAccount.phone_number;

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
                if (foundAccount == null || foundAccount.is_deleted == true)
                {
                    return NotFound("Cannot Find Account");
                }

                var existingAccountByEmail = _accountService.GetAll().FirstOrDefault(x => x.email == request.Email && x.is_deleted == false);
                if (request.Email != null && !request.Email.Equals(foundAccount.email))
                {
                    if (existingAccountByEmail != null)
                        return BadRequest("email Is Already Used");
                    foundAccount.email = request.Email;
                }
                foundAccount.fullname = request.FullName ?? foundAccount.fullname;
                foundAccount.address = request.Address ?? foundAccount.address;
                foundAccount.phone_number = request.PhoneNumber ?? foundAccount.phone_number;
                foundAccount.role = request.Role;
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
                if (foundAccount == null || foundAccount.is_deleted == true)
                {
                    return NotFound("Cannot Find Account");
                }
                if (foundAccount.role == RoleType.Admin)
                {
                    return BadRequest("User With Admin role Cannot Be Inactived");
                }
                switch (foundAccount.status)
                {
                    case AccountStatus.Active:
                        foundAccount.status = AccountStatus.Banned;
                        break;
                    case AccountStatus.Banned:
                        foundAccount.status = AccountStatus.Active;
                        break;
                    default:
                        foundAccount.status = AccountStatus.Active;
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
                if (foundAccount == null || foundAccount.is_deleted == true)
                {
                    return NotFound("Cannot Find Account");
                }
                if (foundAccount.role == RoleType.Admin)
                {
                    return BadRequest("User With Admin role Cannot Be Deleted");
                }
                foundAccount.is_deleted = true;
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
                  new(ClaimTypes.Email, account.email),
                  new(ClaimTypes.Role, account.role.ToString()),
                  new("userId", account.id.ToString()),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
