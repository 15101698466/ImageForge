using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class ImageRecord:DataBase
	{
		[Description("外键")]
		[Column("TaskId", TypeName = "int")]
		public int TaskId { get; set; }

		[Description("原图路径")]
		[Column("OriginalPath", TypeName = "varchar(256)")]
		public string OriginalPath { get; set; }

		[Description("输出路径")]
		[Column("OutputPath", TypeName = "varchar(256)")]
		public string OutputPath { get; set; }


		[Description("处理前文件大小")]
		[Column("OriginalSize", TypeName = "BIGINT")]
		public long OriginalSize { get; set; }

		[Description("处理后文件大小")]
		[Column("CompressedSize", TypeName = "BIGINT")]
		public long CompressedSize { get; set; }


		[Description("处理结果路径")]
		[Column("MD5Hash", TypeName = "varchar(256)")]
		public string MD5Hash { get; set; }


		[Description("标记是否已成功上传至WebAPI")]
		[Column("UploadedToApi", TypeName = "int")]
		public int UploadedToApi { get; set; }


		[Description("WebAPI返回的资源ID，用于后续管理")]
		[Column("AssetId", TypeName = "varchar(256)")]
		public string AssetId { get; set; }
		 
	}
}
