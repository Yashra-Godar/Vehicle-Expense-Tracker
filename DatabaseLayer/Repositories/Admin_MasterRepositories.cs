using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class Admin_MasterRepositories : IAdmin_Master
    {
        private readonly ApplicationDBContext _dbContext;
        public Admin_MasterRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseResult> DeleteAdmin_Master(int Id)
        {
            try
            {

                var result = await _dbContext.tbl_Admin_Master.FindAsync(Id);
                if (result != null)
                {
                    _dbContext.tbl_Admin_Master.Remove(result);
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

        public async Task<ResponseResult> ListAdmin_Master()
        {
            try
            {

                var result = await _dbContext.tbl_Admin_Master.Select(o=> new
                {
                    o.Id,
                    o.FullName,
                    o.ContactNo,
                    o.Email,
                    o.Password
                }).ToListAsync();
                await _dbContext.SaveChangesAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }
            
        

        public async Task<ResponseResult> SaveAdmin_Master(Admin_Master admin_Master)
        {
            try
            {
                List<string> error = new List<string>();
                var result = await _dbContext.tbl_Admin_Master.ToListAsync();
                if (result.Any(o => o.ContactNo == admin_Master.ContactNo))
                {
                    error.Add("ContactNo already exists!");
                }
                if (result.Any(o => o.Email == admin_Master.Email))
                {
                    error.Add("Email already exists!");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_Admin_Master.AddAsync(admin_Master);
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

        public async Task<ResponseResult> UpdateAdmin_Master(int Id, Admin_Master admin_Master)
        {
            try
            {
                var result = await _dbContext.tbl_Admin_Master.FindAsync(Id);
                if (result != null)
                {
                    result.FullName = admin_Master.FullName;
                    result.ContactNo=admin_Master.ContactNo;
                    result.Email = admin_Master.Email;
                    result.Password = admin_Master.Password;
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








