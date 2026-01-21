using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class Service_MasterRepositories : IService_Master
    {
        private readonly ApplicationDBContext _dbContext;
        public Service_MasterRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task<ResponseResult> DeleteService(int Id)
        {
            try
            {

                var result = await _dbContext.tbl_ServiceMaster.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_ServiceMaster.Remove(result);
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

        public async Task<ResponseResult> ListService()
        {
            try
            {
                var result = await _dbContext.tbl_ServiceMaster.ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveService(Service_Master service)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == service.Vehicle_TypeId))
                {
                    error.Add("VehicleType_Id does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_ServiceMaster.AddAsync(service);
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", service);
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

        public async Task<ResponseResult> UpdateService(int Id, Service_Master service)
        {
            try
            {
                var result = await _dbContext.tbl_ServiceMaster.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == service.Vehicle_TypeId))
                    {
                        return new ResponseResult("Fail", "Vehicle_Type id not exists");
                    }
                    result.Vehicle_TypeId = service.Vehicle_TypeId;
                    result.Service_Date= DateTime.Now;
                    result.Service_Type = service.Service_Type;
                    result.Performed_By = service.Performed_By;
                    result.Remark= service.Remark;
                    result.Cost= service.Cost;
                    result.Updated_At = DateTime.Now;

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
