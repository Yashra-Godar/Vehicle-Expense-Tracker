using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILoan_Installment
    {
        public Task<ResponseResult>SaveLoan_Installment(Loan_Installment loan_installment);

        public Task<ResponseResult> UpdateLoan_Installment(int Id,Loan_Installment loan_installment);

        public Task<ResponseResult> DeleteLoan_Installment(int Id);

        public Task<ResponseResult> ListLoan_Installment();

        public Task<ResponseResult> LoanInstallmentReport(DateTime fromDate, DateTime toDate);

        public Task<ResponseResult> LoanInstallmentReminderList();
    }
}
