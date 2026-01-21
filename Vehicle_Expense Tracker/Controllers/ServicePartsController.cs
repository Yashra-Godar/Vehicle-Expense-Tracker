using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePartsController : ControllerBase
    {
        private readonly IService_Parts _Parts;
        public ServicePartsController(IService_Parts Parts)
        {
            _Parts = Parts;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveService_Parts(Service_Parts service_Parts)
        {
            try
            {
                var result=await _Parts.SaveService_Parts(service_Parts);
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
                return StatusCode(500, new ResponseResult("Fail", ex.Message));
            }
        }

        [HttpPut("Update/{Id}")]

        public async Task<IActionResult>UpdateService_Parts(int Id, Service_Parts service_Parts)
        {
            try
            {
                var result=await _Parts.UpdateService_Parts(Id, service_Parts);
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
                return StatusCode(500, new ResponseResult("Fail", ex.Message));
            }

        }

        [HttpDelete("Delete/{Id}")]

        public async Task<IActionResult> DeleteService_Parts(int Id)
        {
            try
            {
                var result = await _Parts.DeleteService_Parts(Id);
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
                return StatusCode(500, new ResponseResult("Fail", ex.Message));
            }

        }

        [HttpGet("List")]

        public async Task<IActionResult>ListService_Parts()
        {
            try
            {
                var result= await _Parts.ListService_Parts();
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
                return StatusCode(500, new ResponseResult("Fail", ex.Message));
            }

        }

    }
            
    
}
