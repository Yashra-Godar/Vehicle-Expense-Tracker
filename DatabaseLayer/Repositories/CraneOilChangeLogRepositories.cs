using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseLayer.Repositories
{
    public class CraneOilChangeLogRepositories : ICraneOilChangeLog
    {
        private readonly ApplicationDBContext _dbContext;
        public CraneOilChangeLogRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteCraneOilChange(int Id)
        {
            try
            {

                var result = await _dbContext.craneOilChangeLogs.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.craneOilChangeLogs.Remove(result);
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

        public async Task<ResponseResult> ListOilChange()
        {
            try
            {
                var result = await _dbContext.craneOilChangeLogs.ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveCraneOilChange(CraneOilChangeLog craneOilChangeLog)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == craneOilChangeLog.Vehicle_TypeId))
                {
                    error.Add("Vehicle_TypeId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.craneOilChangeLogs.AddAsync(craneOilChangeLog);
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", craneOilChangeLog);
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

        public async Task<ResponseResult> UpdateCraneOilChange(int Id, CraneOilChangeLog craneOilChangeLog)
        {
            try 
            { 
            var result = await _dbContext.craneOilChangeLogs.FindAsync(Id);
            
            if (result != null)
            {
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == craneOilChangeLog.Vehicle_TypeId))
                {
                    return new ResponseResult("Fail", "Vehicle_TypeId does not exist");
                }
                    result.Vehicle_TypeId = craneOilChangeLog.Vehicle_TypeId;
                    result.Oil_Type=craneOilChangeLog.Oil_Type;
                    result.Oil_Brand = craneOilChangeLog.Oil_Brand;
                    result.Oil_Qty = craneOilChangeLog.Oil_Qty;
                    result.Unit=craneOilChangeLog.Unit;
                    result.Meter_Reading=craneOilChangeLog.Meter_Reading;
                    result.Change_Date = craneOilChangeLog.Change_Date;
                    result.NextDue_Date = craneOilChangeLog.NextDue_Date;
                    result.Changed_By=craneOilChangeLog.Changed_By;
                    result.Remarks = craneOilChangeLog.Remarks;

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

