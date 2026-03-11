using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IInsurance_Premium
    {
        public Task<ResponseResult> SaveInsurance_Premium(Insurance_Premium insurance_premium);

        public Task<ResponseResult> UpdateInsurance_Premium(int Id,Insurance_Premium insurance_premium);

        public Task<ResponseResult> DeleteInsurance_Premium(int Id);

        public Task<ResponseResult> ListInsurance_Premium();

        public Task<ResponseResult> DetailInsurance_Premium(int Id);

        public Task<ResponseResult> Insurance_PremiumReport(DateTime fromDate, DateTime toDate);





    }
}
