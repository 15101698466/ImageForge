using ImageForge.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageForge.ViewModels
{
	public class ContentViewModel:BindableBase
	{
		private IRegionManager regionManager;

		private IEventAggregator eventAggregator;


		private string strWatermark;

		public string StrWatermark
		{
			get { return strWatermark; }
			set { strWatermark = value; RaisePropertyChanged(); }
		}


		public ContentViewModel(IRegionManager region,IEventAggregator aggregator) 
		{
			this.regionManager = region;
			this.eventAggregator = aggregator;

			eventAggregator.GetEvent<EventMessage>().Subscribe(ReceiveMessage);
		}

		private void ReceiveMessage(Dictionary<string, string> dictionary)
		{
			if (dictionary != null)
			{
				return;
			}
			if(dictionary.ContainsKey("Target"))
			{
				if(dictionary["Target"] == "Content")
				{
					if(dictionary.ContainsKey("Message"))
					{
						switch(dictionary["Message"])
						{
							case "Start":
								//开始处理图片
								break;
							case "Stop":
								//停止处理图片
								break;
							default:
								//打开文件
								LoadImage(dictionary["Message"]);
								break;
						}
						 
					}
				}
			}
		}


		private void StartProcess()
		{
			//开始处理图片的逻辑
		}

		private void StopProcess()
		{
			//停止处理图片的逻辑
		}

		private async Task LoadImage(string strPath)
		{
		
		}

		private void ShowImage()
		{
			//显示图片的逻辑
		}
	}
}
