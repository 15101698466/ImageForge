using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
	public class DataBase
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Description("主键​")]
		[Column("Id", Order = 1)]
		public int ID { get; set; }

		[Description("状态​")]
		[Column("Status", TypeName = "int")]
		public int Status { get; set; } = 0;

		[Description("激活状态​")]
		[Column("Action", TypeName = "int")]
		public int Action { get; set; } = 0;

		[Description("创建事件​")]
		[Column("CreatedTime", TypeName = "DateTime")]
		public DateTime? CreatedTime { get; set; }

		[Description("最后一次更新时间​")]
		[Column("LastUpdatedTime", TypeName = "DateTime")]
		public DateTime? LastUpdatedTime { get; set; }

	}
}
