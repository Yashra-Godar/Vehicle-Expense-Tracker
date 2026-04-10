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
    public class Loan_InstallmentRepositories : ILoan_Installment
    {
        private readonly ApplicationDBContext _dbContext;
        public Loan_InstallmentRepositories(ApplicationDBContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<ResponseResult> DeleteLoan_Installment(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_LoanInstallment.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_LoanInstallment.Remove(result);
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

        public async Task<ResponseResult> ListLoan_Installment()
        {
            try
            {
                var result = await _dbContext.tbl_LoanInstallment.Select(o=> new
                {

                    o.Id,
                    VehicleLoan = new
                    {
                        o.Vehicle_LoanId,
                        o.Vehicle_Loan!.Loan_Provider,
                        o.Vehicle_Loan!.Loan_Amount,
                        o.Vehicle_Loan!.Monthly_Installment,
                    },
                    Staff= new
                    {
                        o.Staff_MasterId,
                        o.Staff_Master!.FullName,
                    },
                    o.Installment_Date,
                    
                    o.Amount_Paid,
                    o.Payment_Method,
                    o.Receipt_No,
                    o.Paid_On,
                    o.Status,
                    o.Note,
                    o.Created_At
                }).ToListAsync();
                return new ResponseResult("OK", result);
            }

            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveLoan_Installment(Loan_Installment loan_installment)
        {
            try
            {
                List<string> error = new List<string>();
                if (!await _dbContext.tbl_VehicleLoan.AnyAsync(o => o.Id == loan_installment.Vehicle_LoanId))
                {
                    error.Add("Vehicle_LoanId does not exist");
                }
                if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == loan_installment.Staff_MasterId))
                {
                    error.Add("Staff_MasterId does not exist");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_LoanInstallment.AddAsync(loan_installment);
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
                return new ResponseResult("Fail",ex.Message);
            }
        }

        public async Task<ResponseResult> UpdateLoan_Installment(int Id, Loan_Installment loan_installment)
        {   
            try
            {
                var result = await _dbContext.tbl_LoanInstallment.FindAsync(Id);
                if (result != null)
                {
                    if (!await _dbContext.tbl_VehicleLoan.AnyAsync(o => o.Id == loan_installment.Vehicle_LoanId))
                    {
                        return new ResponseResult("Fail", "Vehicle_Type id not exists");
                    }
                    if (!await _dbContext.tbl_Staff_Master.AnyAsync(o => o.Id == loan_installment.Staff_MasterId))
                    {
                        return new ResponseResult("Fail", "Vehicle_Type id not exists");
                    }

                    result.Vehicle_LoanId=loan_installment.Vehicle_LoanId;
                    result.Staff_MasterId=loan_installment.Staff_MasterId;
                    result.Installment_Date=loan_installment.Installment_Date;
                    result.Amount_Paid=loan_installment.Amount_Paid;
                    result.Payment_Method=loan_installment.Payment_Method;
                    result.Receipt_No=loan_installment.Receipt_No;
                    result.Paid_On=loan_installment.Paid_On;
                    result.Status=loan_installment.Status;
                    result.Note=loan_installment.Note;
                    result.Updated_At=loan_installment.Updated_At;

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

        public async Task<ResponseResult> LoanInstallmentReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                {
                    return new ResponseResult("Fail", "From date cannot be greater than To date");
                }

                var result = await _dbContext.tbl_LoanInstallment
                    .Where(o => o.Installment_Date.Date >= fromDate.Date &&  o.Installment_Date.Date <= toDate.Date)
                    .Select(o => new
                    {
                        o.Id,
                        VehicleLoan = new
                        {
                            o.Vehicle_LoanId,
                            o.Vehicle_Loan!.Loan_Provider,
                            o.Vehicle_Loan!.Loan_Amount,
                            o.Vehicle_Loan!.Monthly_Installment,
                            o.Vehicle_Loan!.Crane_Vehicle!.Vehicle_Name,
                            o.Vehicle_Loan!.Crane_Vehicle!.Vehicle_No
                        },
                        Staff = new
                        {
                            o.Staff_MasterId,
                            o.Staff_Master!.FullName,
                        },
                        o.Installment_Date,
                        o.Amount_Paid,
                        o.Payment_Method,
                        o.Receipt_No,
                        o.Paid_On,
                        o.Status,
                        o.Note,
                        o.Created_At
                    }).ToListAsync();

                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> LoanInstallmentReminderList()
        {
            try
            {

                DateTime today = DateTime.Now.Date;
                DateTime next7Days = today.AddDays(7);

                var result = await _dbContext.tbl_LoanInstallment
                    .Where(o =>
                        o.Installment_Date.Date <= next7Days // upcoming
                    )
                    .Select(o => new
                    {
                        o.Id,

                        vehicle = new
                        {

                            o.Vehicle_Loan!.Crane_Vehicle!.Vehicle_Name,
                            o.Vehicle_Loan!.Crane_Vehicle!.Vehicle_No
                        },

                        VehicleLoan = new
                        {
                            o.Vehicle_LoanId,
                            o.Vehicle_Loan!.Loan_Provider,
                            o.Vehicle_Loan!.Loan_Amount,
                            o.Vehicle_Loan!.Monthly_Installment,
                            o.Vehicle_Loan!.Crane_Vehicle!.Vehicle_Name,
                            o.Vehicle_Loan!.Crane_Vehicle!.Vehicle_No
                        },
                        o.Installment_Date,
                        o.Amount_Paid,
                        o.Payment_Method,
                        o.Receipt_No,
                        o.Paid_On,
                        o.Note,
                        o.Created_At,

                    

                        Status = o.Installment_Date.Date < today
                            ? "Overdue"
                            : "Upcoming"
                    })
                    .OrderBy(o => o.Installment_Date)
                    .Take(10) // limit for dashboard
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
