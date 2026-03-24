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

        public async Task<ResponseResult> DetailCrane_Vehicle(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_CraneVehicle.Where(o => o.Id == Id).Select(o => new
                {
                    o.Id,
                    staff = new
                    {
                        o.Staff_MasterId,
                        o.Staff_Master!.FullName,
                    },
                    
                    o.Vehicle_Name,
                    o.Vehicle_No,
                    o.Vehicle_Type!.TypeName,
                    o.Make_by,
                    o.Manufacture_Year,
                    o.Capacity_Tons,
                    o.Max_Lifting_Height,
                    o.Created_At,
                    o.Import_Date,
                    o.Import_From,
                    o.Purchase_Type,
                    o.Remarks,
                    
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

        




        public async Task<VehicleSummaryDTO> GetVehicleSummaryAsync(int id)
        {
            try
            {
                var result = await (
                    from v in _dbContext.tbl_CraneVehicle
                    where v.Id == id
                    select new VehicleSummaryDTO
                    {
                        VehicleNo = v.Vehicle_No,
                        VehicleName = v.Vehicle_Name,
                        VehicleType = v.Vehicle_Type != null ? v.Vehicle_Type.TypeName : "",
                        MakeBy = v.Make_by,
                        Model = v.Model,
                        ManufactureYear = v.Manufacture_Year,
                        StaffName = v.Staff_Master != null ? v.Staff_Master.FullName : "",
                        CapacityTons = v.Capacity_Tons,
                        PurchaseType = v.Purchase_Type,
                        Note=v.Note,

                        TotalFuelExpense = _dbContext.tbl_FuelExpenses
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .Sum(x => (decimal?)x.Fuel_Qty) ?? 0,

                        TotalServiceExpense = _dbContext.tbl_ServiceMaster
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .Sum(x => (decimal?)x.Cost) ?? 0,

                        TotalOtherExpense = _dbContext.craneOtherExpenses
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .Sum(x => (decimal?)x.Amount) ?? 0,

                        TotalInsuranceAmount = _dbContext.tbl_CraneInsurance
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .Sum(x => (decimal?)x.Premium_Frequency) ?? 0,

                        TotalLoanPaid = _dbContext.tbl_VehicleLoan
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .Sum(x => (decimal?)x.Loan_Amount) ?? 0,

                        LastFuelDate = _dbContext.tbl_FuelExpenses
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .OrderByDescending(x => x.Fuel_Date)
                            .Select(x => (DateTime?)x.Fuel_Date)
                            .FirstOrDefault(),

                        LastServiceDate = _dbContext.tbl_ServiceMaster
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .OrderByDescending(x => x.Service_Date)
                            .Select(x => (DateTime?)x.Service_Date)
                            .FirstOrDefault(),

                        LastOilChangeDate = _dbContext.craneOilChangeLogs
                            .Where(x => x.Crane_VehicleId == v.Id)
                            .OrderByDescending(x => x.Created_At)
                            .Select(x => (DateTime?)x.Created_At)
                            .FirstOrDefault(),

                        TotalFuelEntries = _dbContext.tbl_FuelExpenses
                            .Count(x => x.Crane_VehicleId == v.Id),

                        TotalServices = _dbContext.tbl_ServiceMaster
                            .Count(x => x.Crane_VehicleId == v.Id),

                        TotalOilChanges = _dbContext.craneOilChangeLogs
                            .Count(x => x.Crane_VehicleId == v.Id)
                    }).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching vehicle summary", ex);
            }
        }




        public async Task<ResponseResult> ListCrane_Vehicle()
        {
            try
            {
                var result = await _dbContext.tbl_CraneVehicle.Select(o=> new
                {

                    o.Id,
                    vehicleType = new
                    {
                        o.Vehicle_TypeId,
                        o.Vehicle_Type!.TypeName,
                    },
                    Staff = new
                    {
                        o.Staff_MasterId,
                        o.Staff_Master!.FullName,
                    },
                                        
                    o.Vehicle_Name,
                    o.Vehicle_No,
                    o.Make_by,
                    o.Model,
                    o.Manufacture_Year,
                    o.Capacity_Tons,
                    o.Max_Lifting_Height,
                    o.Import_From,
                    o.Note,
                    o.Import_Date,
                    o.Purchase_Type,
                    o.Created_At

                    
                }).ToListAsync();
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
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == crane_Vehicle.Staff_MasterId))
                {
                    error.Add("Staff_MasterId does not exist");
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
                        return new ResponseResult("Fail","Vehicle_Type Id not exists");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == crane_Vehicle.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId not exists");
                    }
                    
                    result.Vehicle_TypeId = crane_Vehicle.Vehicle_TypeId;
                    result.Staff_MasterId=crane_Vehicle.Staff_MasterId;
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

        public async Task<ResponseResult> vehicle_Report(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                {
                    return new ResponseResult("Fail", "From date cannot be greater than To date");
                }

                var result = await _dbContext.tbl_CraneVehicle
                    .Where(o => o.Import_Date.Date >= fromDate.Date && o.Import_Date.Date <= toDate.Date)
                    .Select(o => new
                    {
                        o.Id,
                        vehicleType = new
                        {
                            o.Vehicle_TypeId,
                            o.Vehicle_Type!.TypeName,
                        },

                        Staff = new
                        {
                            o.Staff_MasterId,
                            o.Staff_Master!.FullName,
                        },
                       o.Vehicle_No,
                       o.Vehicle_Name,
                       o.Model, 
                       o.Manufacture_Year,
                       o.Max_Lifting_Height,
                       o.Capacity_Tons,
                       o.Make_by,
                       o.Import_From,
                       o.Import_Date,
                       o.Purchase_Type,
                       o.Note
                    })
                    .ToListAsync();

                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }
    }
}
