using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseLayer.Repositories
{
    public class Vehicle_TypeRepositories : IVehicle_Type
    {
        private readonly ApplicationDBContext _dbContext;
        public Vehicle_TypeRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseResult> DeleteVehicle_Type(int Id)
        {
            try
            {
                var result=  await _dbContext.tbl_Vehicles.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_Vehicles.Remove(result);
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

        public async Task<ResponseResult> ListVehicle_Type()
        {
            try
            {
                var result=await _dbContext.tbl_Vehicles.ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }

        }

        public  async Task<ResponseResult> SaveVehicle_Type(Vehicle_Type vehicle_Type)
        {
            try
            {
                 _dbContext.tbl_Vehicles.Add(vehicle_Type);
                  await _dbContext.SaveChangesAsync();
                  return new ResponseResult("OK", "Data Inserted Successfully");
            }
                
            
            catch (Exception ex)
            {
                return new ResponseResult("Fail",ex.Message);
            }
        }

        public async Task<ResponseResult> UpdateVehicle_Type(int Id, Vehicle_Type vehicle_Type)
        {
            try
            {
                var result = await _dbContext.tbl_Vehicles.FindAsync(Id);
                if (result != null)
                {
                    result.TypeName = vehicle_Type.TypeName;
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
