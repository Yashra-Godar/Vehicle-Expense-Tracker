using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceMasterController : ControllerBase
    {
        private readonly IService_Master _Master;
        public ServiceMasterController(IService_Master Master)
        {
            _Master = Master;
        }
        [HttpPost("Save")]
        public async Task<IActionResult>SaveService(Service_Master service)
        {
            try
            {
                var result= await _Master.SaveService(service);
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
        public async Task<IActionResult> UpdateService(int Id, Service_Master service)
        {
            try
            {
                var result = await _Master.UpdateService(Id, service);
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
        public async Task<IActionResult>DeleteService(int Id)
        {
            try
            {
                var result=await _Master.DeleteService(Id);
                if(result.status == "OK")
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
        public async Task<IActionResult> ListService()
        {
            try
            {
                var result = await _Master.ListService();
                if(result.status == "OK")
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
