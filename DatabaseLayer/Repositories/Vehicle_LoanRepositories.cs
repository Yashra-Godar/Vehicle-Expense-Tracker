using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class Vehicle_LoanRepositories : IVehicle_Loan
    {
        private readonly ApplicationDBContext _dbContext;
        public Vehicle_LoanRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteVehicle_Loan(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_VehicleLoan.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_VehicleLoan.Remove(result);
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", "Data Removed Successfully");
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

        public async Task<ResponseResult> ListVehicle_Loan()
        {
            try
            {
                var result=await _dbContext.tbl_VehicleLoan.ToListAsync();
                return new ResponseResult("OK", result);            
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveVehicle_Loan(Vehicle_Loan vehicle_loan)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == vehicle_loan.Vehicle_TypeId))
                {
                    error.Add("VehicleType_Id does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_VehicleLoan.AddAsync(vehicle_loan);
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", vehicle_loan);
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

        public async Task<ResponseResult> UpdateVehicle_Loan(int Id, Vehicle_Loan vehicle_loan)
        {
            try
            {
                var result = await _dbContext.tbl_VehicleLoan.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_Vehicles.AnyAsync(o => o.Id == vehicle_loan.Vehicle_TypeId))
                    {
                        return new ResponseResult("Fail", "Vehicle_Type id not exists");
                    }
                    result.Vehicle_TypeId = vehicle_loan.Vehicle_TypeId;
                    result.Loan_Provider = vehicle_loan.Loan_Provider;
                    result.Loan_Amount = vehicle_loan.Loan_Amount;
                    result.Interest_Rate = vehicle_loan.Interest_Rate;
                    result.Term_Month = vehicle_loan.Term_Month;
                    result.Start_Date = vehicle_loan.Start_Date;
                    result.Monthly_Installment = vehicle_loan.Monthly_Installment;
                    result.Status = vehicle_loan.Status;
                    result.Contact_Detail = vehicle_loan.Contact_Detail;
                    result.Updated_At = vehicle_loan.Updated_At;

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
