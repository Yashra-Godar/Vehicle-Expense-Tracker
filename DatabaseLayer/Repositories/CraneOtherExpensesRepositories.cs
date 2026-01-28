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

        public async Task<ResponseResult> DetailCraneOtherExpenses(int Id)
        {
            try
            {
                var result = await _dbContext.craneOtherExpenses.Where(o => o.Id == Id).Select(o => new
                {
                    o.Id,
                    vehicle = new
                    {
                        o.Crane_VehicleId,
                        o.Crane_Vehicle!.Vehicle_Name,
                        o.Crane_Vehicle!.Vehicle_No,
                        o.Crane_Vehicle!.Max_Lifting_Height,
                        o.Crane_Vehicle!.Capacity_Tons,
                        o.Crane_Vehicle!.Make_by,
                        o.Crane_Vehicle!.Manufacture_Year
                    },
                    staff = new
                    {
                        o.Staff_MasterId,
                        o.Staff_Master!.FullName,
                    },
                    o.Expense_Type,
                    o.Amount,
                    o.Expense_Date,
                    o.Paid_To,
                    o.Reference_No,
                    o.Description,
                    o.Payment_Mode,
                    o.Created_At
                }).FirstOrDefaultAsync();
                if (result != null)
                {

                    return new ResponseResult("OK", result);

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
                    vehicle = new
                    {
                        o.Crane_VehicleId,
                        o.Crane_Vehicle!.Vehicle_Name,
                        o.Crane_Vehicle!.Vehicle_No,
                        o.Crane_Vehicle!.Max_Lifting_Height,
                        o.Crane_Vehicle!.Capacity_Tons,
                        o.Crane_Vehicle!.Make_by,
                        o.Crane_Vehicle!.Manufacture_Year
                    },
                    staff = new
                    {
                        o.Staff_MasterId,
                        o.Staff_Master!.FullName,
                    },
                    o.Expense_Type,
                    o.Amount,
                    o.Expense_Date,
                    o.Paid_To,
                    o.Reference_No,
                    o.Description,
                    o.Payment_Mode,
                    o.Created_At
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
                    if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == craneOtherExpenses.Crane_VehicleId))
                    {
                        error.Add("Crane_VehicleId does not exist");
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
                    if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == craneOtherExpenses.Crane_VehicleId))
                    {
                        return new ResponseResult("Fail", "Crane_VehicleId does not exist");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == craneOtherExpenses.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId does not exist");
                    }
                    result.Crane_VehicleId = craneOtherExpenses.Crane_VehicleId;
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
