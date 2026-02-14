using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCentreController : ControllerBase
    {
        private readonly IServiceCentre _service;
        public ServiceCentreController(IServiceCentre service)
        {
            _service = service;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> SaveService_Centre(ServiceCentre serviceCentre)
        {
            try
            {
                var result = await _service.SaveService_Centre(serviceCentre);
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
        public async Task<IActionResult> ListService_Centre()
        {
            try
            {
                var result = await _service.ListService_Centre();
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

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult>UpdateService_Centre(int Id, ServiceCentre serviceCentre)
        {
            try
            {
                var result = await _service.UpdateService_Centre(Id, serviceCentre);
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
        public async Task<IActionResult>DetailService_Centre(int Id)
        {
               
            try
            {
                var result = await _service.DetailService_Centre(Id);
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
   
