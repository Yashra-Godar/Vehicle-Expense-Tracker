using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IService_Parts
    {
        public Task<ResponseResult> SaveService_Parts(Service_Parts service_Parts);

        public Task<ResponseResult> UpdateService_Parts(int Id,Service_Parts service_Parts);

        public Task<ResponseResult> ListService_Parts();

        public Task<ResponseResult>DeleteService_Parts(int Id);




    }
}
