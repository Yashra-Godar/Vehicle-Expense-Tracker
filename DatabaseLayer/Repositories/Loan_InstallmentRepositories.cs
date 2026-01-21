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
                var result = await _dbContext.tbl_LoanInstallment.ToListAsync();
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
                if (error.Count == 0)
                {
                    await _dbContext.tbl_LoanInstallment.AddAsync(loan_installment);
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", loan_installment);
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
                    result.Vehicle_LoanId=loan_installment.Vehicle_LoanId;
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
    }
}
