using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Expense_Tracker.Helper;
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

        public async Task<IActionResult> SaveAdmin_Master(Admin_Master admin_Master)
        {
            try
            {
                var result = await _Master.SaveAdmin_Master(admin_Master);
                if (result != null)
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

        [HttpPost("Create")]

        public async Task<IActionResult> CreateAdmin_Master([FromBody] Admin_Master admin_Master)
        {
            string plainPassword = PasswordHelper.GeneratePassword();

            admin_Master.Password = PasswordHelper.HashPassword(plainPassword);
            

            await _Master.Create_AdminMaster(admin_Master);

            // ✅ Use injected service
             
            _adminEmail.SendCredentials(
                admin_Master.Email,
                admin_Master.FullName,
                plainPassword
            );

            return Ok(new { message = "Admin created and credentials emailed." });
        }


    }
}
