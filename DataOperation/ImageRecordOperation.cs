using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
	public class ImageRecordOperation
	{

		public async Task<bool> SaveImageRecord(ImageRecord image)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{ 
					await dbContext.ImageRecord.AddAsync(image);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> SaveImageRecords(List<ImageRecord>  images)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					dbContext.ImageRecord.AddRangeAsync(images);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> UpdateImageRecord(ImageRecord image)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var existingImage = await dbContext.ImageRecord.FindAsync(image.ID);
					if (existingImage != null)
					{
						image.ID = existingImage.ID;
					}
					dbContext.ImageRecord.Update(image);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> UpdateImageRecords( List<ImageRecord>  images)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					foreach (var image in images)
					{
						var existingImage = await dbContext.ImageRecord.FindAsync(image.ID);
						if (existingImage != null)
						{
							image.ID = existingImage.ID;
						}
					}
					dbContext.ImageRecord.UpdateRange(images);
					await dbContext.SaveChangesAsync();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<List<ImageRecord>> GetImageRecordsByTaskId(int taskId, int pIndex, int pCount)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var images = await dbContext.ImageRecord.Where(x => x.TaskId == taskId).Skip(pIndex * pCount).Take(pCount).AsNoTracking().ToListAsync();
					return images;
				}
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<ImageRecord>> GetImageRecord(int pIndex,int pCount)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var image = await dbContext.ImageRecord.Skip(pIndex*pCount).Take(pCount).AsNoTracking().ToListAsync();

					return image;
				}
			}
			catch
			{
				return null;
			}
		}

		public async Task<ImageRecord> GetImageRecordById(int id)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var image = await dbContext.ImageRecord.FindAsync(id);
					return image;
				}
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> DeleteImageRecord(int id)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var image = await dbContext.ImageRecord.FindAsync(id);
					if (image != null)
					{
						dbContext.ImageRecord.Remove(image);
						await dbContext.SaveChangesAsync();
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

		public async Task<bool> DeleteImageRecords(List<int> ids)
		{
			try
			{
				using (var dbContext = new AppDbContext())
				{
					var images = await dbContext.ImageRecord.Where(x => ids.Contains(x.ID)).ToListAsync();
					if (images.Count > 0)
					{
						dbContext.ImageRecord.RemoveRange(images);
						await dbContext.SaveChangesAsync();
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
