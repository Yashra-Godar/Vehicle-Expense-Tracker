using BusinessLayer.Helper;
using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Expense_Tracker.Services;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMasterController : ControllerBase
    {
        private readonly IAdmin_Master _Master;
        private readonly AdminEmailServices _adminEmail;
        public AdminMasterController(IAdmin_Master Master, AdminEmailServices adminEmail)
        {
            _Master = Master;
            _adminEmail = adminEmail;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveAdmin_Master([FromBody] Admin_Master admin_Master)
        {
            try
            {
                // ✅ Generate automatic password
                string plainPassword = PasswordHelper.GeneratePassword();

                // ✅ Hash password before saving
                admin_Master.Password = PasswordHelper.HashPassword(plainPassword);

                // ✅ Save to database
                var result = await _Master.SaveAdmin_Master(admin_Master);

                if (result.status == "OK")
                {
                    // ✅ Send credentials via email
                    _adminEmail.SendCredentials(
                        admin_Master.Email,
                        admin_Master.FullName,
                        plainPassword
                    );

                    return Ok(new ResponseResult("OK", "Admin created and credentials emailed."));
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }
        

        [HttpPut("Update/{Id}")]

        public async Task<IActionResult> UpdateAdmin_Master(int Id, Admin_Master admin_Master)
        {
            try
            {
                var result = await _Master.UpdateAdmin_Master(Id, admin_Master);
                if (result.status == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }

        [HttpDelete("Delete/{Id}")]

        public async Task<IActionResult> DeleteAdmin_Master(int Id)
        {
            {
                try
                {
                    var result = await _Master.DeleteAdmin_Master(Id);
                    if (result.status == "OK")
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result);
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
                }
            }
        }


        [HttpGet("List")]
        public async Task<IActionResult> ListAdmin_Master()
        {
            try
            {
                var result = await _Master.ListAdmin_Master();
                if (result.status == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }


        [HttpGet("Detail/{Id}")]
        public async Task<IActionResult> DetailAdmin_Master(int Id)
        {
            try
            {
                var result = await _Master.DetailAdmin_Master(Id);
                if (result.status == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }

        

        [HttpPost("Login")]
        public async Task<IActionResult> AdminLogin([FromBody] AdminLoginDTO model)
        {
            try
            {
                var result = await _Master.AdminLogin(model.Email, model.Password);

                if (result.status == "OK")
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            try
            {
                var result = await _Master.ChangePassword(model);

                if (result.status == "OK")
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult("Internal Server Error", ex.Message));
            }
        }
    }

    public class AdminLoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    
}
