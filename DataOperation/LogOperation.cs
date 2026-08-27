using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
	public class LogOperation
	{
		public async Task<bool> SaveLogRecord(LogEntity log)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					await dbContext.LogEntity.AddAsync(log);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> SaveLogRecords(List<LogEntity> logs)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					dbContext.LogEntity.AddRangeAsync(logs);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<List<LogEntity>> GetLogEntities(DateTime startTime,DateTime endTime,int pIndex,int pCount)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					return await dbContext.LogEntity.Where(r=>r.CreatedTime>=startTime&& r.CreatedTime<=endTime).AsNoTracking().Skip(pIndex* pCount).Take(pCount).ToListAsync();
				}
			}
			catch
			{
				return new List<LogEntity>();
			}
		}
	}
}
