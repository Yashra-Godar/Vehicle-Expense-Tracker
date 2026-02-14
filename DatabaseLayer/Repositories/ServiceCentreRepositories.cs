using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories
{
    public class ServiceCentreRepositories : IServiceCentre
    {
        private readonly ApplicationDBContext _dbContext;
        public ServiceCentreRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public async Task<ResponseResult> DetailService_Centre(int Id)
        {
            try
            {

                var result = await _dbContext.tbl_ServiceCentre.Where(o => o.Id == Id).Select(o => new
                {
                    o.Id,
                    o.Name,
                    o.Address,
                    o.ContactNo,
                    o.Email,
                    o.CreatedAt

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
        

        public async Task<ResponseResult> ListService_Centre()
        {
            try
            {

                var result = await _dbContext.tbl_ServiceCentre.Select(o => new
                {
                    o.Id,
                    o.Name,
                    o.Address,
                    o.ContactNo,
                    o.Email,
                    o.CreatedAt
                }).ToListAsync();
                await _dbContext.SaveChangesAsync();
                return new ResponseResult("OK", result);
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }
            
        

        public async Task<ResponseResult> SaveService_Centre(ServiceCentre serviceCentre)
        {
            try
            {
                List<string> error = new List<string>();
                var result = await _dbContext.tbl_ServiceCentre.ToListAsync();
                if (result.Any(o => o.ContactNo == serviceCentre.ContactNo))
                {
                    error.Add("ContactNo already exists!");
                }
                if (result.Any(o => o.Email == serviceCentre.Email))
                {
                    error.Add("Email already exists!");
                }
                if (error.Count == 0)
                {
                    await _dbContext.tbl_ServiceCentre.AddAsync(serviceCentre);
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

        public async Task<ResponseResult> UpdateService_Centre(int Id, ServiceCentre serviceCentre)
        {
            try
            {
                var result = await _dbContext.tbl_ServiceCentre.FindAsync(Id);
                if (result != null)
                {
                    result.Name = serviceCentre.Name;
                    result.Address = serviceCentre.Address;
                    result.ContactNo=serviceCentre.ContactNo;
                    result.Email = serviceCentre.Email;
                   

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
