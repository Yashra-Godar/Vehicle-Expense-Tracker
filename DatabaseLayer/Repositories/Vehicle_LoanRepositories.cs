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

        public async Task<ResponseResult> DetailVehicle_Loan(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_VehicleLoan.Where(o => o.Id == Id).Select(o => new
                {
                    o.Id,
                    vehicleType= new
                    {
                        o.Crane_Vehicle!.Vehicle_TypeId,
                        o.Crane_Vehicle!.Vehicle_Type!.TypeName,

                    },
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
                    o.Loan_Provider,
                    o.Loan_Amount,
                    o.Interest_Rate,
                    o.Term_Month,
                    o.Start_Date,
                    o.Monthly_Installment,
                    o.Status,
                    o.Contact_Detail,
                    o.Created_At,
                    installments = o.loan_Installments.Select(l=> new
                    {
                        l.Id,
                        l.Installment_Date,
                        l.Amount_Paid,
                        l.Payment_Method,
                        l.Receipt_No
                    }),
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

        public async Task<ResponseResult> ListVehicle_Loan()
        {
            try
            {
                var result=await _dbContext.tbl_VehicleLoan.Select(o=> new
                {
                    o.Id,
                    vehicle = new
                    {
                        o.Crane_VehicleId,
                        o.Crane_Vehicle!.Vehicle_Name,
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
                    o.Loan_Provider,
                    o.Loan_Amount,
                    o.Interest_Rate,
                    o.Term_Month,
                    o.Start_Date,
                    o.Monthly_Installment,
                    o.Status,
                    o.Contact_Detail,
                    o.Created_At,
                    installments = o.loan_Installments.Select(l => new
                    {
                        l.Id,
                        l.Installment_Date,
                        l.Amount_Paid,
                        l.Payment_Method,
                        l.Receipt_No
                    }),

                }).ToListAsync();
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
                if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == vehicle_loan.Crane_VehicleId))
                {
                    error.Add(" Crane_VehicleId does not exist");
                }
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == vehicle_loan.Staff_MasterId))
                {
                    error.Add("Staff_MasterId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_VehicleLoan.AddAsync(vehicle_loan);
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

        public async Task<ResponseResult> UpdateVehicle_Loan(int Id, Vehicle_Loan vehicle_loan)
        {
            try
            {
                var result = await _dbContext.tbl_VehicleLoan.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_CraneVehicle.AnyAsync(o => o.Id == vehicle_loan.Crane_VehicleId))
                    {
                        return new ResponseResult("Fail", "Crane_VehicleId  does not exists");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == vehicle_loan.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", " Staff_MasterId does not exists");
                    }
                    result.Crane_VehicleId = vehicle_loan.Crane_VehicleId;
                    result.Staff_MasterId = vehicle_loan.Staff_MasterId;
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
