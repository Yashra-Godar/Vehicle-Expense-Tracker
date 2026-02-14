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

        public async Task<ResponseResult> DetailService(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_ServiceMaster.Where(o => o.Id == Id).Select(o => new
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

                   
                    serviceParts = o.service_Parts.Select(o => new
                    {
                        o.Id,
                        o.Parts_Name,
                        o.Qty,
                        o.Unit_Cost,
                        o.Total_Cost,
                        o.Created_At
                    }),
                    serviceCentre = new
                    {

                        o.ServiceCentreId,
                        o.ServiceCentre!.Name,
                        o.ServiceCentre!.Address,
                        o.ServiceCentre!.ContactNo,
                        o.ServiceCentre!.Email,
                        o.ServiceCentre!.CreatedAt,

                    },
                    o.Service_Date,
                    o.Service_Type,
                    o.Performed_By,
                    o.Remark,
                    o.Cost,
                    o.Created_At,

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

        public async Task<ResponseResult> ListService()
        {
            try
            {
                var result = await _dbContext.tbl_ServiceMaster.Select(o=> new
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
                    serviceParts = o.service_Parts.Select(o => new
                    {
                        o.Id,
                        o.Parts_Name,
                        o.Qty,
                        o.Unit_Cost,
                        o.Total_Cost,
                        o.Created_At
                    }),
                    

                  
                    serviceCentre = new
                    {

                        o.ServiceCentreId,
                        o.ServiceCentre!.Name,
                        o.ServiceCentre!.Address,
                        o.ServiceCentre!.ContactNo,
                        o.ServiceCentre!.Email,
                        o.ServiceCentre!.CreatedAt,

                    },
                    o.Service_Date,
                    o.Service_Type,
                    o.Performed_By,
                    o.Remark,
                    o.Cost,
                    o.Created_At,
                }).ToListAsync();
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
                if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == service.Crane_VehicleId))
                {
                    error.Add("Crane_VehicleId does not exist");
                }
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == service.Staff_MasterId))
                {
                    error.Add("Staff_MasterId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_ServiceMaster.AddAsync(service);
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

        public async Task<ResponseResult> UpdateService(int Id, Service_Master service)
        {
            try
            {
                var result = await _dbContext.tbl_ServiceMaster.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == service.Crane_VehicleId))
                    {
                        return new ResponseResult("Fail", "Crane_VehicleId not exists");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == service.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId not exists");
                    }
                    result.Crane_VehicleId = service.Crane_VehicleId;
                    result.Staff_MasterId = service.Staff_MasterId;
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
