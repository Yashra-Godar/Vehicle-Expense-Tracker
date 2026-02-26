using BusinessLayer.Helper;
using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseLayer.Repositories
{
    public class Staff_MasterRepositories : IStaff_Master
    {
        private readonly ApplicationDBContext _dbContext;
        public Staff_MasterRepositories(ApplicationDBContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<ResponseResult> ChangeStaffPassword(ChangePasswordDTO model)
        {
            
        {
            try
            {
                var admin = await _dbContext.tbl_Staff_Master.FindAsync(model.Id);

                if (admin == null)
                    return new ResponseResult("Fail", "Admin not found");

                if (model.NewPassword != model.ConfirmPassword)
                    return new ResponseResult("Fail", "New password and confirm password do not match");

                // Compare plain old password
                if (admin.Password != model.OldPassword)
                    return new ResponseResult("Fail", "Old password is incorrect");

                // Store plain new password
                admin.Password = model.NewPassword;

                await _dbContext.SaveChangesAsync();

                return new ResponseResult("OK", "Password changed successfully");
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }
        }

        public async  Task<ResponseResult> CreateStaff_Master(Staff_Master staff_master)
        {
            try
            {
                _dbContext.tbl_Staff_Master.Add(staff_master);
                await _dbContext.SaveChangesAsync();
                return new ResponseResult("OK", "Staff account created Successfully and login credentials send to email");
            
        }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> DeleteStaff_Master(int Id)
        {
            try
            {
                
                    var result = await _dbContext.tbl_Staff_Master.FindAsync(Id);
                    if (result != null)
                    {
                       _dbContext.tbl_Staff_Master.Remove(result);
                      await _dbContext.SaveChangesAsync();
                      return new ResponseResult("OK", "Data Deleted Successfully");
                    }
                    else
                    {
                        return new ResponseResult("Fail", "Not Found");
                    }
                
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }

        }

        public async Task<ResponseResult> DetailStaff_Master(int Id)
        {
            try
            {
                var result = await _dbContext.tbl_Staff_Master.Where(o => o.Id == Id).Select(o => new
                {
                    o.Id,
                    o.FullName,
                    o.ContactNo,
                    o.Email,
                    o.Password,
                    o.IsActive
                }).FirstOrDefaultAsync();
                if (result != null)
                {

                    return new ResponseResult("OK", result);

                }
                else
                {
                    return new ResponseResult("Fail", "Not Found");
                }

            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }


        public async Task<ResponseResult> ListStaff_Master()
        {
            try
            {
                var result= await _dbContext.tbl_Staff_Master.Select(o=> new
                {
                    o.Id,
                    o.FullName,
                    o.ContactNo,
                    o.Email,
                    o.Password,
                    o.IsActive
                }).ToListAsync();
                await _dbContext.SaveChangesAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public async Task<ResponseResult> SaveStaff_Master(Staff_Master staff_master)
        {
            try
            { 
                List<string>error=new List<string>();
                var result=  await _dbContext.tbl_Staff_Master.ToListAsync();   
                if (result.Any(o=>o.ContactNo==staff_master.ContactNo))
                {
                    error.Add("ContactNo already exists!");
                }
                if (result.Any(o => o.Email == staff_master.Email))
                {
                    error.Add("Email already exists!");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_Staff_Master.AddAsync(staff_master);
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", "Data Inserted Successfully");
                }
                else
                {
                    return new ResponseResult("Fail", error);
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }

        }

        public async Task<ResponseResult> StaffLogin(string email, string password)
        {
            var staff = await _dbContext.tbl_Staff_Master.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (staff == null)
                return new ResponseResult("ERROR", "Invalid email or password");

            return new ResponseResult("OK", new
            {
                staff.Id,
                staff.FullName,
                staff.Email
            });
        }

        public async Task<ResponseResult> UpdateStaff_Master(int Id, Staff_Master staff_master)
        {
            try
            {
                var result = await _dbContext.tbl_Staff_Master.FindAsync(Id);
                if (result != null)
                {
                    result.FullName= staff_master.FullName;
                    result.ContactNo=staff_master.ContactNo;
                    result.Email= staff_master.Email;
                    result.Password = staff_master.Password;
                    result.IsActive=staff_master.IsActive;
                    
                    await _dbContext.SaveChangesAsync();
                    return new ResponseResult("OK", "Data Updated Successfully");
                }
                else
                {
                    return new ResponseResult("Fail", "Data not Found");
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }

        }
    }
}
