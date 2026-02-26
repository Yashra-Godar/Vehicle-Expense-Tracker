using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IStaff_Master
    {
        public Task<ResponseResult> SaveStaff_Master(Staff_Master staff_master);

        public Task<ResponseResult> UpdateStaff_Master(int Id,Staff_Master staff_master);

        public Task<ResponseResult> DeleteStaff_Master(int Id);

        public Task<ResponseResult> ListStaff_Master();
        public Task<ResponseResult> DetailStaff_Master(int Id);

        public Task<ResponseResult> CreateStaff_Master(Staff_Master staff_master);
        Task<ResponseResult> StaffLogin(string email, string password);

        Task<ResponseResult> ChangeStaffPassword(ChangePasswordDTO model);




    }
}
