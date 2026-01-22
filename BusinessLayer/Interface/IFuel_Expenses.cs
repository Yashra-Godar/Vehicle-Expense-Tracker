using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFuel_Expenses
    {
        public Task<ResponseResult> SaveFuel_Expenses(Fuel_Expenses fuel_Expenses);

        public Task<ResponseResult> UpdateFuel_Expenses(int Id,Fuel_Expenses fuel_Expenses);

        public Task<ResponseResult> ListFuel_Expenses();

        public Task<ResponseResult> DeleteFuel_Expenses(int Id);
    }
}
