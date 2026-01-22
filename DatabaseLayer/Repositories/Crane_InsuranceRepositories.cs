using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class Crane_InsuranceRepositories : ICrane_Insurance
    {
        private readonly ApplicationDBContext _dbContext;
        public Crane_InsuranceRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteCrane_Insurance(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_CraneInsurance.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_CraneInsurance.Remove(result);
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

        public async Task<ResponseResult> ListCrane_Insurance()
        {
            try
            {
                var result = await _dbContext.tbl_CraneInsurance.ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }
        

        public async Task<ResponseResult> SaveCrane_Insurance(Crane_Insurance crane_Insurance)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == crane_Insurance.Vehicle_TypeId))
                {
                    error.Add("Vehicle_TypeId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_CraneInsurance.AddAsync(crane_Insurance);
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

        public async Task<ResponseResult> UpdateCrane_Insurance(int Id, Crane_Insurance crane_Insurance)
        {
            try
            {
                var result = await _dbContext.tbl_CraneInsurance.FindAsync(Id);

                if (result != null)
                {
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == crane_Insurance.Vehicle_TypeId))
                    {
                        return new ResponseResult("Fail", "Vehicle_TypeId does not exist");
                    }

                    result.Vehicle_TypeId = crane_Insurance.Vehicle_TypeId;
                    result.Policy_No=crane_Insurance.Policy_No;
                    result.Insurance_Company=crane_Insurance.Insurance_Company;
                    result.Policy_Type = crane_Insurance.Policy_Type;
                    result.Start_Date=crane_Insurance.Start_Date;
                    result.End_Date = crane_Insurance.End_Date;
                    result.Premium_Amount=crane_Insurance.Premium_Amount;
                    result.Premium_Frequency = crane_Insurance.Premium_Frequency;
                    result.Agent_Name=crane_Insurance.Agent_Name;
                    result.Agent_ContactNo = crane_Insurance.Agent_ContactNo;
                    result.Remarks=crane_Insurance.Remarks;

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
    

