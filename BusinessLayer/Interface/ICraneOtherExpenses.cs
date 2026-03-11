using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICraneOtherExpenses
    {
        public Task<ResponseResult> SaveCraneOtherExpenses(CraneOtherExpenses craneOtherExpenses);

        public Task<ResponseResult> UpdateCraneOtherExpenses(int Id,CraneOtherExpenses craneOtherExpenses);

        public Task<ResponseResult> ListCraneOtherExpenses();

        public Task<ResponseResult> DeleteCraneOtherExpenses(int Id);

        public Task<ResponseResult> DetailCraneOtherExpenses(int Id);

        public Task<ResponseResult> CraneOtherExpenses_Report(DateTime fromDate, DateTime toDate);
    }
}
