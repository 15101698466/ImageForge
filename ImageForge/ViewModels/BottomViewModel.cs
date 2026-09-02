using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageForge.ViewModels
{
	public class BottomViewModel:BindableBase
	{
		private int imageCount;

		public int ImageCount
		{
			get { return imageCount; }
			set { imageCount = value; RaisePropertyChanged(); }
		}

		private int imageIndex;

		public int ImageIndex
		{
			get { return imageIndex; }
			set { imageIndex = value; RaisePropertyChanged(); }
		}

		private int taskCount;

		public int TaskCount
		{
			get { return taskCount; }
			set { taskCount = value; RaisePropertyChanged(); }
		}

		private DateTime consumptionTime;

		public DateTime ConsumptionTime
		{
			get { return consumptionTime; }
			set { consumptionTime = value; RaisePropertyChanged(); }
		}

		private double dProcesses;

		public double DProcesses
		{
			get { return dProcesses; }
			set { dProcesses = value; RaisePropertyChanged(); }
		}




		public BottomViewModel()
		{

		}
	}
}
