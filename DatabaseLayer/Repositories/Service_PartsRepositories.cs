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
    public class Service_PartsRepositories : IService_Parts
    {
        private readonly ApplicationDBContext _dbContext;
        public Service_PartsRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteService_Parts(int Id)
        {
            try
            {

                var result = await _dbContext.tbl_ServiceParts.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_ServiceParts.Remove(result);
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
        

        public async Task<ResponseResult> ListService_Parts()
        {
            try
            {
                var result = await _dbContext.tbl_ServiceParts.Select(o=> new
                {
                    o.Id,
                    o.Service_MasterId,
                    o.Service_Master!.Service_Type,   
                    o.Service_Master!.Performed_By,
                    o.Staff_MasterId,
                    o.Staff_Master!.FullName,
                    o.Parts_Name,
                    o.Qty,
                    o.Unit_Cost,
                    o.Total_Cost,
                    o.Remark,
                    o.Created_At
                }).ToListAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveService_Parts(Service_Parts service_Parts)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_ServiceMaster.AnyAsync(o => o.Id == service_Parts.Service_MasterId))
                {
                    error.Add("Service_MasterId does not exist");
                }
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == service_Parts.Staff_MasterId))
                {
                    error.Add("Staff_MasterId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_ServiceParts.AddAsync(service_Parts);
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

        public async Task<ResponseResult> UpdateService_Parts(int Id, Service_Parts service_Parts)
        {
            try
            {
                var result = await _dbContext.tbl_ServiceParts.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_ServiceMaster.AnyAsync(o => o.Id == service_Parts.Service_MasterId))
                    {
                        return new ResponseResult("Fail", "Service_MasterId does not exist");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == service_Parts.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId does not exist");
                    }
                    result.Service_MasterId = service_Parts.Service_MasterId;
                    result.Parts_Name = service_Parts.Parts_Name;
                    result.Qty = service_Parts.Qty;
                    result.Unit_Cost = service_Parts.Unit_Cost;
                    result.Total_Cost = service_Parts.Total_Cost;
                    result.Remark = service_Parts.Remark;
                    result.Updated_At = service_Parts.Updated_At;

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
