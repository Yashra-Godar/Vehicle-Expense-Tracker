using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICrane_Vehicle
    {
        public Task<ResponseResult> SaveCrane_Vehicle(Crane_Vehicle crane_Vehicle);

        public Task<ResponseResult> UpdateCrane_Vehicle(int Id,Crane_Vehicle crane_Vehicle);

        public Task<ResponseResult> DeleteCrane_Vehicle(int Id);

        public Task<ResponseResult> ListCrane_Vehicle();
        




    }
}
