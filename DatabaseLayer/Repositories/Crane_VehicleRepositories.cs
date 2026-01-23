using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace DatabaseLayer.Repositories
{
    public class Crane_VehicleRepositories : ICrane_Vehicle
    {
        private readonly ApplicationDBContext _dbContext;
        public Crane_VehicleRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteCrane_Vehicle(int Id)
        {
            try
            {
                var result=  await _dbContext.tbl_CraneVehicle.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_CraneVehicle.Remove(result);
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

        public async Task<ResponseResult> ListCrane_Vehicle()
        {
            try
            {
                var result = await _dbContext.tbl_CraneVehicle.ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }

        }

        public async  Task<ResponseResult> SaveCrane_Vehicle(Crane_Vehicle crane_Vehicle)
        {
            try
            {

                List<string> error = new List<string>();
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == crane_Vehicle.Vehicle_TypeId))
                {
                    error.Add("VehicleType_Id does not exist");
                }
                var result = await _dbContext.tbl_CraneVehicle.ToListAsync();
                if (result.Any(o=>o.Vehicle_No==crane_Vehicle.Vehicle_No)) 
                {
                    error.Add("Vehicle_No already exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_CraneVehicle.AddAsync(crane_Vehicle);
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

        public async Task<ResponseResult> UpdateCrane_Vehicle(int Id, Crane_Vehicle crane_Vehicle)
        {
            try
            {
                var result =  await _dbContext.tbl_CraneVehicle.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == crane_Vehicle.Vehicle_TypeId)) {
                        return new ResponseResult("Fail","Vehicle_Type id not exists");
                    }
                    result.Vehicle_TypeId = crane_Vehicle.Vehicle_TypeId;
                    result.Vehicle_No = crane_Vehicle.Vehicle_No;
                    result.Vehicle_Name = crane_Vehicle.Vehicle_Name;
                    result.Make_by=crane_Vehicle.Make_by;
                    result.Model = crane_Vehicle.Model;
                    result.Manufacture_Year=crane_Vehicle.Manufacture_Year;
                    result.Capacity_Tons=crane_Vehicle.Capacity_Tons;
                    result.Max_Lifting_Height = crane_Vehicle.Max_Lifting_Height;
                    result.Import_From = crane_Vehicle.Import_From;
                    result.Note=crane_Vehicle.Note;
                    result.Import_Date = crane_Vehicle.Import_Date;
                    result.Purchase_Type = crane_Vehicle.Purchase_Type;
                    result.Updated_At = DateTime.Now;
                    result.Remarks=crane_Vehicle.Remarks;

                    
                   
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
