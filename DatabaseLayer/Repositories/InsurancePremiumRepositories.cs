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

        public async Task<ResponseResult> DetailInsurance_Premium(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_InsurancePremium.Where(o => o.Id == Id).Select(o => new
                {
                    o.Id,
                    CraneInsurance = new
                    {
                        o.Crane_Insurance!.Insurance_Company,
                        o.Crane_Insurance!.Policy_No,
                        o.Crane_Insurance!.Policy_Type,
                        o.Crane_Insurance!.Created_At,
                    },

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
                    o.Premium_Month,
                    o.Payment_Date,
                    o.Amount_Date,
                    o.Payment_Mode,
                    o.Paid_To,
                    o.Remarks,
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

        public async Task<ResponseResult> ListInsurance_Premium()
        {
            try
            {
                var result = await _dbContext.tbl_InsurancePremium.Select(o=> new
                {
                    o.Id,
                    CraneInsurance = new
                    {
                        o.Crane_Insurance!.Insurance_Company,
                        o.Crane_Insurance!.Policy_No,
                        o.Crane_Insurance!.Policy_Type,
                        o.Crane_Insurance!.Created_At,
                    },

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
                    o.Premium_Month,
                    o.Payment_Date,
                    o.Amount_Date,
                    o.Payment_Mode,
                    o.Paid_To,
                   o.Remarks,
                   o.Created_At
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
                if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == insurance_premium.Crane_VehicleId))
                {
                    error.Add("Crane_VehicleId does not exist");
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
                    if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == insurance_premium.Crane_VehicleId))
                    {
                        return new ResponseResult("Fail", "Crane_VehicleId not exists");
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
                    result.Crane_VehicleId = insurance_premium.Crane_VehicleId;
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
