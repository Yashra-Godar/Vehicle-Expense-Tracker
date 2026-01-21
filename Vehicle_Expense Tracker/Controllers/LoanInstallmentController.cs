using BusinessLayer.Interface;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanInstallmentController : ControllerBase
    {
        private readonly ILoan_Installment _Installment;
        public LoanInstallmentController(ILoan_Installment Installment)
        {
            _Installment = Installment;
        }

        [HttpPost("Save")]

        public async Task<IActionResult> SaveLoan_Installment(Loan_Installment LoanInstallment)
        {
            try
            {
                var result = await _Installment.SaveLoan_Installment(LoanInstallment);
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
        public async Task<IActionResult> UpdateLoan_Installment(int Id, Loan_Installment loan_installment)
        {
            try
            {
                var result = await _Installment.UpdateLoan_Installment(Id, loan_installment);
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

        public async Task<IActionResult> DeleteLoan_Installment(int Id)
        {
            try
            {
                var result = await _Installment.DeleteLoan_Installment(Id);
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

        public async Task<IActionResult> ListLoan_Installment()
        {
            try
            {
                var result = await _Installment.ListLoan_Installment();
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
    

