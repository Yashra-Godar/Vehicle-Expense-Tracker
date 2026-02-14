using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IServiceCentre
    {
        public Task<ResponseResult> SaveService_Centre(ServiceCentre serviceCentre);

        public Task<ResponseResult> UpdateService_Centre(int Id,ServiceCentre serviceCentre);

        public Task<ResponseResult> ListService_Centre();

        public Task<ResponseResult> DetailService_Centre(int Id);



    }
}
