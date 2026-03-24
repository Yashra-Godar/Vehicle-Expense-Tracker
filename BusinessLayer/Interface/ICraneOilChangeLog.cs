using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICraneOilChangeLog
    {
        public Task<ResponseResult> SaveCraneOilChange(CraneOilChangeLog craneOilChangeLog);

        public Task<ResponseResult> UpdateCraneOilChange(int Id,CraneOilChangeLog craneOilChangeLog);

        public Task<ResponseResult> DeleteCraneOilChange(int Id);

        public Task<ResponseResult> ListOilChange();

        public Task<ResponseResult> DetailCraneOilChange(int Id);

        public Task<ResponseResult> CraneOilChange_Report(DateTime fromDate, DateTime toDate);



    }
}
