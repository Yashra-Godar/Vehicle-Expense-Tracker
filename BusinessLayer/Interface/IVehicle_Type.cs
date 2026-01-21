using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IVehicle_Type
    {
        public Task<ResponseResult>SaveVehicle_Type(Vehicle_Type vehicle_Type);
        public Task<ResponseResult> UpdateVehicle_Type(int Id, Vehicle_Type vehicle_Type);
        public Task<ResponseResult> ListVehicle_Type();

        public Task<ResponseResult> DeleteVehicle_Type(int Id);




    }
}
