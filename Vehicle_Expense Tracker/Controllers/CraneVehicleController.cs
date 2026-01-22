using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraneVehicleController : ControllerBase
    {
        private readonly ICrane_Vehicle _craneVehicle;
        public CraneVehicleController(ICrane_Vehicle craneVehicle)
        {
            _craneVehicle = craneVehicle;
        }
        [HttpPost("Save")]
        public async Task<IActionResult>SaveCrane_Vehicle(Crane_Vehicle crane_Vehicle)
        {
            try
            {
                var result=await _craneVehicle.SaveCrane_Vehicle(crane_Vehicle);
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
        public async Task<IActionResult> UpdateCrane_Vehicle(int id, Crane_Vehicle crane_vehicle)
        {
            try
            {
                var result=await _craneVehicle.UpdateCrane_Vehicle(id, crane_vehicle);
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
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult>DeleteCrane_Vehicle(int Id)
        {
            try
            {
                var result=await _craneVehicle.DeleteCrane_Vehicle(Id);
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

        [HttpGet("List")]
        public async Task<IActionResult> ListCrane_Vehicle()
        {
            try
            {
                var result = await _craneVehicle.ListCrane_Vehicle();
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

    }

