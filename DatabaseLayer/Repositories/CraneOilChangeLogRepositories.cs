using Azure;
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

        public async Task<ResponseResult> CraneOilChange_Report(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                {
                    return new ResponseResult("Fail", "From date cannot be greater than To date");
                }

                var result = await _dbContext.craneOilChangeLogs
                    .Where(o => o.Created_At.Date >= fromDate.Date && o.Created_At.Date <= toDate.Date)
                    .Select(o => new
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

                        Staff = new
                        {
                            o.Staff_MasterId,
                            o.Staff_Master!.FullName,
                        },
                        o.Oil_Type,
                        o.Oil_Brand,
                        o.Oil_Qty,
                        o.Changed_By,
                        o.Unit,
                        o.Meter_Reading,
                        o.Remarks,
                        o.Created_At
                    })
                    .ToListAsync();

                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
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

        public async Task<ResponseResult> DetailCraneOilChange(int Id)
        {
            try
            {
                var result = await _dbContext.craneOilChangeLogs.Where(o => o.Id == Id).Select(o => new

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
                    o.Oil_Type,
                    o.Oil_Brand,
                    o.Oil_Qty,
                    o.Unit,
                    o.Meter_Reading,
                 
                    o.Changed_By,
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

        public async Task<ResponseResult> ListOilChange()
        {
            try
            {
                var result = await _dbContext.craneOilChangeLogs.Select(o=> new
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
                    o.Oil_Type,
                    o.Oil_Brand,
                    o.Oil_Qty,
                    o.Unit,
                    o.Meter_Reading,
                    
                    o.Changed_By,
                    o.Remarks,
                    o.Created_At,
                }).ToListAsync();
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
                if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == craneOilChangeLog.Crane_VehicleId))
                {
                    error.Add("crane_vehicleId does not exist");
                }
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == craneOilChangeLog.Staff_MasterId))
                {
                    error.Add("Staff_MasterId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.craneOilChangeLogs.AddAsync(craneOilChangeLog);
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

        public async Task<ResponseResult> UpdateCraneOilChange(int Id, CraneOilChangeLog craneOilChangeLog)
        {
            try 
            { 
            var result = await _dbContext.craneOilChangeLogs.FindAsync(Id);
            
            if (result != null)
            {
                if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == craneOilChangeLog.Crane_VehicleId))
                {
                    return new ResponseResult("Fail", "Crane_vehicleId does not exist");
                }
                 if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == craneOilChangeLog.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId does not exist");
                    }
                    result.Crane_VehicleId = craneOilChangeLog.Crane_VehicleId;
                    result.Staff_MasterId = craneOilChangeLog.Staff_MasterId;
                    result.Oil_Type=craneOilChangeLog.Oil_Type;
                    result.Oil_Brand = craneOilChangeLog.Oil_Brand;
                    result.Oil_Qty = craneOilChangeLog.Oil_Qty;
                    result.Unit=craneOilChangeLog.Unit;
                    result.Meter_Reading=craneOilChangeLog.Meter_Reading;
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

