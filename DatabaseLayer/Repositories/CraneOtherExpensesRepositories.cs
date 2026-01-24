using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class CraneOtherExpensesRepositories : ICraneOtherExpenses
    {
        private readonly ApplicationDBContext _dbContext;
        public CraneOtherExpensesRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteCraneOtherExpenses(int Id)
        {
            try
            {
                var result = await _dbContext.craneOtherExpenses.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.craneOtherExpenses.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", "Data Deleted Successfully");

                }
                else
                {
                    return new ResponseResult("Fail", "Not Found");
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }
        

        public async Task<ResponseResult> ListCraneOtherExpenses()
        {
            try
            {
                var result = await _dbContext.craneOtherExpenses.Select(o => new
                {
                    o.Id,
                    o.Vehicle_TypeId,
                    o.Vehicle_Type!.TypeName,
                    o.Staff_MasterId,
                    o.Staff_Master!.FullName,
                    o.Expense_Type,
                    o.Amount,
                    o.Expense_Date,
                    o.Paid_To,
                    o.Reference_No,
                    o.Description,
                    o.Payment_Mode
                }).ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveCraneOtherExpenses(CraneOtherExpenses craneOtherExpenses)
        {
            
                try
                {
                    List<string> error = new List<string>();
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == craneOtherExpenses.Vehicle_TypeId))
                    {
                        error.Add("Vehicle_TypeId does not exist");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == craneOtherExpenses.Staff_MasterId))
                   {
                      error.Add("Staff_MasterId does not exist");
                   }
                if (error.Count == 0)
                    {
                        await _dbContext.craneOtherExpenses.AddAsync(craneOtherExpenses);
                        await _dbContext.SaveChangesAsync();
                        return new ResponseResult("OK", "Data Inserted Successfully");
                    }
                    else
                    {
                        return new ResponseResult("Fail", error);
                    }
                }

                catch (Exception ex)
                {
                    return new ResponseResult("Fail", ex.Message);
                }
            }

            
            
                
            
        

        public async Task<ResponseResult> UpdateCraneOtherExpenses(int Id, CraneOtherExpenses craneOtherExpenses)
        {
            try
            {
                var result = await _dbContext.craneOtherExpenses.FindAsync(Id);

                if (result != null)
                {
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == craneOtherExpenses.Vehicle_TypeId))
                    {
                        return new ResponseResult("Fail", "Vehicle_TypeId does not exist");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == craneOtherExpenses.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId does not exist");
                    }
                    result.Vehicle_TypeId = craneOtherExpenses.Vehicle_TypeId;
                    result.Staff_MasterId = craneOtherExpenses.Staff_MasterId;
                    result.Expense_Type=craneOtherExpenses.Expense_Type;
                    result.Amount = craneOtherExpenses.Amount;
                    result.Expense_Date = craneOtherExpenses.Expense_Date;
                    result.Paid_To=craneOtherExpenses.Paid_To;
                    result.Reference_No=craneOtherExpenses.Reference_No;
                    result.Description = craneOtherExpenses.Description;
                    result.Payment_Mode=craneOtherExpenses.Payment_Mode;
                    
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", "Data Updated Successfully");
                }
                else
                {
                    return new ResponseResult("Fail", "Data not Found");
                }

            }
            
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }
    }
}
