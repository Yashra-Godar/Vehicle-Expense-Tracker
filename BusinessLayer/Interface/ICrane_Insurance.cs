using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICrane_Insurance
    {
        public Task<ResponseResult>SaveCrane_Insurance(Crane_Insurance crane_Insurance);

        public Task<ResponseResult> UpdateCrane_Insurance(int Id,Crane_Insurance crane_Insurance);

        public Task<ResponseResult> ListCrane_Insurance();

        public Task<ResponseResult> DeleteCrane_Insurance(int Id);

        public Task<ResponseResult> DetailCrane_Insurance(int Id);






    }
}
