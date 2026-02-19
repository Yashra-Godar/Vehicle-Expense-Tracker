using Azure.Core;
using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Expense_Tracker.Helper;
using Vehicle_Expense_Tracker.Services;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMasterController : ControllerBase
    {
        private readonly IStaff_Master _Master;
        private readonly EmailService _emailService;
        
        public StaffMasterController(IStaff_Master Master,EmailService emailService)
        {
            _Master = Master;
            _emailService = emailService;
        }
        


        [HttpPost("Save")]
        public async Task<IActionResult> SaveStaff_Master(Staff_Master staff_Master)
        {
            try
            {
                var result = await _Master.SaveStaff_Master(staff_Master);
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
        public async Task<IActionResult> UpdateStaff_Master(int Id, Staff_Master staff_Master)
        {

            try
            {
                var result = await _Master.UpdateStaff_Master(Id, staff_Master);
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
        public async Task<IActionResult> DeleteStaff_Master(int Id)
        {
            try
            {
                var result = await _Master.DeleteStaff_Master(Id);
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

        [HttpGet("List")]
        public async Task<IActionResult> ListStaff_Master()
        {
            try
            {
                var result = await _Master.ListStaff_Master();
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
        public async Task<IActionResult> DetailStaff_Master(int Id)
        {
            try
            {
                var result = await _Master.DetailStaff_Master(Id);
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

        public async Task <IActionResult> CreateStaff([FromBody] Staff_Master staff_Master)
        {
            string plainPassword = PasswordHelper.GeneratePassword();

            
            staff_Master.Password = PasswordHelper.HashPassword(plainPassword);
            staff_Master.Created_At = DateTime.Now;

            await _Master.CreateStaff_Master(staff_Master);


            
            _emailService.SendCredentials(staff_Master.Email, staff_Master.FullName, plainPassword);



            return Ok(new { message = "Staff created and credentials emailed." });

        }


    }
}