using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class InsurancePremiumRepositories : IInsurance_Premium
    {
        private readonly ApplicationDBContext _dbContext;
        public InsurancePremiumRepositories(ApplicationDBContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<ResponseResult> DeleteInsurance_Premium(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_InsurancePremium.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_InsurancePremium.Remove(result);
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

        public async Task<ResponseResult> ListInsurance_Premium()
        {
            try
            {
                var result = await _dbContext.tbl_InsurancePremium.Select(o=> new
                {
                    o.Id,
                    o.Crane_Insurance!.Insurance_Company,
                    o.Crane_Insurance!.Policy_No,
                    o.Crane_Insurance!.Policy_Type,
                    o.Vehicle_TypeId,
                    o.Vehicle_Type!.TypeName,
                    o.Staff_MasterId,
                    o.Staff_Master!.FullName,
                    o.Premium_Month,
                    o.Payment_Date,
                    o.Amount_Date,
                    o.Payment_Mode,
                    o.Paid_To,
                   o.Remarks
                }).ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveInsurance_Premium(Insurance_Premium insurance_premium)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == insurance_premium.Vehicle_TypeId))
                {
                    error.Add("Vehicle_TypeId does not exist");
                }
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == insurance_premium.Staff_MasterId))
                {
                    error.Add(" Staff_MasterId does not exist");
                }
                if (!await _dbContext.tbl_CraneInsurance.AnyAsync(o => o.Id == insurance_premium.Crane_InsuranceId))
                {
                    error.Add("Crane_InsuranceId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_InsurancePremium.AddAsync(insurance_premium);
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

        public  async Task<ResponseResult> UpdateInsurance_Premium(int Id, Insurance_Premium insurance_premium)
        {
            try
            {
                var result = await _dbContext.tbl_InsurancePremium.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == insurance_premium.Vehicle_TypeId))
                    {
                        return new ResponseResult("Fail", "Vehicle_TypeId not exists");
                    }
                    if (!await _dbContext.tbl_CraneInsurance.AnyAsync(o => o.Id == insurance_premium.Crane_InsuranceId))
                    {
                        return new ResponseResult("Fail", "Crane_InsuranceId not exists");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == insurance_premium.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId  not exists");
                    }

                    result.Crane_InsuranceId = insurance_premium.Crane_InsuranceId;
                    result.Vehicle_TypeId = insurance_premium.Vehicle_TypeId;
                    result.Staff_MasterId=insurance_premium.Staff_MasterId;
                    result.Premium_Month=insurance_premium.Premium_Month;
                    result.Payment_Date=insurance_premium.Payment_Date;
                    result.Amount_Date = insurance_premium.Amount_Date;
                    result.Payment_Mode = insurance_premium.Payment_Mode;
                    result.Paid_To = insurance_premium.Paid_To;
                    result.Remarks=insurance_premium.Remarks;

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
