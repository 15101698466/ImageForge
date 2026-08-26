using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class LogEntity:DataBase
	{
		[Description("日志等级")]
		[Column("Level", TypeName = "varchar(256)")]
		public string Level { get; set; }

		[Description("日志级别")]
		[Column("Message", TypeName = "varchar(256)")]
		public string Message { get; set; }  


		[Description("日志来源")]
		[Column("Source", TypeName = "varchar(256)")]
		public string Source { get; set; }
	}
}
