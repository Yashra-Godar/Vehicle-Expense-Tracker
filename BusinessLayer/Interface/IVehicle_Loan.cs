using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IVehicle_Loan
    {
        public Task<ResponseResult>SaveVehicle_Loan(Vehicle_Loan vehicle_loan) ;

        public Task<ResponseResult> UpdateVehicle_Loan(int Id,Vehicle_Loan vehicle_loan);

        public Task<ResponseResult> ListVehicle_Loan();

        public Task<ResponseResult> DeleteVehicle_Loan(int Id);


    }
}
