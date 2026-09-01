using DataModel;
using System.Data.Entity;

namespace DataOperation
{
	public class ProcessTaskOperation
	{
		public async Task<bool> SaveProcessTask(ProcessingTask task)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					await dbContext.ProcessingTask.AddAsync(task);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> UpdateProcessTask(ProcessingTask task)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var existingTask = await dbContext.ProcessingTask.FindAsync(task.ID);
					if (existingTask != null)
					{
						task.ID = existingTask.ID;
					}
					dbContext.ProcessingTask.Update(task);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<List<ProcessingTask>> GetProcessTasks(DateTime startTime, DateTime endTime, int pIndex, int pCount)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					return await dbContext.ProcessingTask.Where(r => r.CreatedTime >= startTime && r.CreatedTime <= endTime).Skip(pIndex * pCount).Take(pCount).AsNoTracking().ToListAsync();
				}
			}
			catch
			{
				return new List<ProcessingTask>();
			}
		}

		public async Task<ProcessingTask> GetProcessTaskById(int taskId)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					return await dbContext.ProcessingTask.FindAsync(taskId);
				}
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> DeleteProcessTask(int taskId)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var task = await dbContext.ProcessingTask.FindAsync(taskId);
					if (task != null)
					{
						dbContext.ProcessingTask.Remove(task);
						dbContext.SaveChangesAsync();
						return true;
					}
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
