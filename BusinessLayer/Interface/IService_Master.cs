using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IService_Master
    {
        public Task<ResponseResult>SaveService(Service_Master service);

        public Task<ResponseResult>UpdateService(int Id, Service_Master service);

        public Task<ResponseResult> ListService();

        public Task<ResponseResult>DeleteService(int Id);


    }
}
