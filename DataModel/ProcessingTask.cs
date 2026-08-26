using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class ProcessingTask: DataBase
	{
		[Description("输入路径")]
		[Column("SourceFolder", TypeName = "varchar(256)")]
		public string SourceFolder { get; set; }

		[Description("输出路径")]
		[Column("OutputFolder", TypeName = "varchar(256)")]
		public string OutputFolder { get; set; }


		[Description("总图片数")]
		[Column("TotalCount", TypeName = "int")]
		public int TotalCount { get; set; } = 0;

		[Description("已完成数")]
		[Column("CompletedCount", TypeName = "int")]
		public int CompletedCount { get; set; } = 0;

	}
}
