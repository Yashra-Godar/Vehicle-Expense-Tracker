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

        public async Task<ResponseResult> ListFuel_Expenses()
        {
            try
            {
                var result = await _dbContext.tbl_FuelExpenses.ToListAsync();
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
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == fuel_Expenses.Vehicle_TypeId))
                {
                    error.Add("VehicleType_Id does not exist");
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
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == fuel_Expenses.Vehicle_TypeId))
                    {
                        return new ResponseResult("Fail", "Vehicle_Type id not exists");
                    }
                    result.Vehicle_TypeId = fuel_Expenses.Vehicle_TypeId;
                    result.Fuel_Date = fuel_Expenses.Fuel_Date;
                    result.Fuel_Source = fuel_Expenses.Fuel_Source;
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
