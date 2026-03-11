using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class Fuel_ExpensesRepositories : IFuel_Expenses
    {
        private readonly ApplicationDBContext _dbContext;
        public Fuel_ExpensesRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteFuel_Expenses(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_FuelExpenses.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_FuelExpenses.Remove(result);
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

        public async  Task<ResponseResult> DetailFuel_Expenses(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_FuelExpenses.Where(o => o.Id == Id).Select(o => new
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
                    o.Fuel_Date,
                    o.Fuel_Source,
                    o.Fuel_Station,
                    o.Fuel_Qty,
                    o.Rate,
                    o.Odometer_Reading,
                    o.Payment_Method,
                    o.Receipt_No,
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

        public async Task<ResponseResult> Fuel_ExpenseReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                {
                    return new ResponseResult("Fail", "From date cannot be greater than To date");
                }

                var result = await _dbContext.tbl_FuelExpenses
                    .Where(o => o.Fuel_Date.Date >= fromDate.Date && o.Fuel_Date.Date <= toDate.Date)
                    .Select(o => new
                    {
                        o.Id,
                       
                        Staff = new
                        {
                            o.Staff_MasterId,
                            o.Staff_Master!.FullName,
                        },
                        o.Fuel_Date,
                        o.Fuel_Qty,
                        o.Fuel_Source,
                        o.Fuel_Station,
                        o.Payment_Method,
                        o.Odometer_Reading,
                        o.Rate,
                        o.Receipt_No,
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

    

        

        public async Task<ResponseResult> ListFuel_Expenses()
        {
            try
            {
                var result = await _dbContext.tbl_FuelExpenses.Select(o=> new
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
                    o.Fuel_Date,
                    o.Fuel_Source,
                    o.Fuel_Station,
                    o.Fuel_Qty,
                    o.Rate,
                    o.Odometer_Reading,
                    o.Payment_Method,
                    o.Receipt_No,
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

        public async Task<ResponseResult> SaveFuel_Expenses(Fuel_Expenses fuel_Expenses)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == fuel_Expenses.Crane_VehicleId))
                {
                    error.Add("Crane_VehicleId does not exist");
                }
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == fuel_Expenses.Staff_MasterId))
                {
                    error.Add("StaffMaster_Id does not exist");
                }

                var result = await _dbContext.tbl_FuelExpenses.ToListAsync();
             
                if (error.Count == 0)
                {
                    await _dbContext.tbl_FuelExpenses.AddAsync(fuel_Expenses);
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


        public async Task<ResponseResult> UpdateFuel_Expenses(int Id, Fuel_Expenses fuel_Expenses)
        {
            try
            {
                var result = await _dbContext.tbl_FuelExpenses.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == fuel_Expenses.Crane_VehicleId))
                    {
                        return new ResponseResult("Fail", " Crane_VehicleId not exists");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == fuel_Expenses.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Staff_MasterId not exists");
                    }
                    result.Crane_VehicleId = fuel_Expenses.Crane_VehicleId;
                    result.Staff_MasterId = fuel_Expenses.Staff_MasterId;
                    result.Fuel_Date = fuel_Expenses.Fuel_Date;
                    result.Fuel_Source = fuel_Expenses.Fuel_Source;
                    result.Fuel_Station = fuel_Expenses.Fuel_Station;
                    result.Fuel_Qty = fuel_Expenses.Fuel_Qty;
                    result.Rate = fuel_Expenses.Rate;
                    result.Odometer_Reading = fuel_Expenses.Odometer_Reading;
                    result.Payment_Method = fuel_Expenses.Payment_Method;
                    result.Receipt_No = fuel_Expenses.Receipt_No;
                    result.Remarks = fuel_Expenses.Remarks;
                    result.Updated_At = fuel_Expenses.Updated_At;

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
