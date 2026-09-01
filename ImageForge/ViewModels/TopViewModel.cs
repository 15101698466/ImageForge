using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Mvvm;
using System.Threading.Tasks;
using Prism.Navigation.Regions;
using Prism.Events;
using Prism.Dialogs;
using Prism.Commands;

namespace ImageForge.ViewModels
{
	public class TopViewModel : BindableBase, INavigationAware
	{
		//消息机制
		private IEventAggregator eventAggregator;

		private IDialogService dialogService;
		

		public DelegateCommand CloseCommnd { get; set; }
		public TopViewModel(IEventAggregator aggregator,IDialogService  dialog)
		{
			this.eventAggregator = aggregator;
			this.dialogService = dialog;
			CloseCommnd = new DelegateCommand(CloseWindow);


		}

		private void CloseWindow()
		{
			 DialogParameters keyValues = new DialogParameters();
			keyValues.Add("message","是否关闭程序");

			dialogService.ShowDialog("CloseAPPView", keyValues, 
				callback:(result)=>
				{
					if (result.Result == ButtonResult.Yes)
					{
						App.Current.Shutdown();
					}
				}
				);

		}

 

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			 
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			  
		}
	}
}
