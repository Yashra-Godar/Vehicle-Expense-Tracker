using BusinessLayer.Interface;
using BusinessLayer.Model;
using DatabaseLayer.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repositories
{
    public class CraneOilChangeLogRepositories : ICraneOilChangeLog
    {
        private readonly ApplicationDBContext _dbContext;
        public CraneOilChangeLogRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<ResponseResult> DeleteCraneOilChange(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> ListOilChange()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResult> SaveCraneOilChange(CraneOilChangeLog craneOilChangeLog)
        {
            try
            {
                var result= _dbContext.craneOilChangeLogs.Add(craneOilChangeLog);
                await _dbContext.SaveChangesAsync();
                return new ResponseResult("OK", "Data Inserted Successfully");
            }
            catch (Exception ex)
            {
                return new ResponseResult("Fail", ex.Message);
            }
        }

        public Task<ResponseResult> UpdateCraneOilChange(int Id, CraneOilChangeLog craneOilChangeLog)
        {
            throw new NotImplementedException();
        }
    }
}
