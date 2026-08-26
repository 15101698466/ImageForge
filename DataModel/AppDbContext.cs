using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration; 
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace DataModel
{
	public class AppDbContext : DbContext
	{

		// 构造函数，接收数据库连接选项
		public AppDbContext()
		{ 
		}

		// DbSet 属性对应数据库中的表
		public Microsoft.EntityFrameworkCore.DbSet<ProcessingTask> ProcessingTask { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<ImageRecord> ImageRecord { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<LogEntity> LogEntity { get; set; }

	

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql(
				"Server=127.0.0.1;Database=imagedata;Port=3306;charset=utf8;uid=root;pwd=hmpt2022;",
				new MySqlServerVersion(new Version(8, 0, 29))
			).LogTo(Console.WriteLine, LogLevel.Information);
		}
	}
}
