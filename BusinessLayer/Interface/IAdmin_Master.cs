using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAdmin_Master
    {
        public Task<ResponseResult>SaveAdmin_Master(Admin_Master admin_Master);

        public Task<ResponseResult> UpdateAdmin_Master(int Id,Admin_Master admin_Master);

        public Task<ResponseResult> ListAdmin_Master();

        public Task<ResponseResult> DeleteAdmin_Master(int Id);



    }
}
