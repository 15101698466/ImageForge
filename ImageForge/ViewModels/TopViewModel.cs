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
using System.Threading;
using Microsoft.Win32;
using ImageForge.Common;

namespace ImageForge.ViewModels
{
	public class TopViewModel : BindableBase, INavigationAware
	{
		//消息机制
		private IEventAggregator eventAggregator;

		private IDialogService dialogService;

		private CancellationTokenSource cancellationToken;

		public DelegateCommand CloseCommand { get; set; }

		public DelegateCommand OpenFileCommand { get; set; }

		public DelegateCommand StartCommand { get; set; }

		public DelegateCommand StopCommand { get; set; }

		public TopViewModel(IEventAggregator aggregator,IDialogService  dialog)
		{
			this.eventAggregator = aggregator;
			this.dialogService = dialog;
			CloseCommand = new DelegateCommand(CloseWindow);
			OpenFileCommand = new DelegateCommand(OpenFile);
			StartCommand = new DelegateCommand(Start);
			StopCommand = new DelegateCommand(Stop);

		}

		private void Stop()
		{  
			SendMessage("Content", "Stop");
		}

		private void Start()
		{ 

			SendMessage("Content", "Start");
		}

		private void OpenFile()
		{
			OpenFolderDialog openFolderDialog = new OpenFolderDialog();
			
			var result =  openFolderDialog.ShowDialog(); 
			SendMessage("Content", openFolderDialog.FolderName);
		}

		private void CloseWindow()
		{
			 DialogParameters keyValues = new DialogParameters();
			keyValues.Add("message","是否关闭程序");

			dialogService.ShowDialog("MessageView", keyValues, 
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

		public void SendMessage(string target, string message)
		{
			Dictionary<string, string> keyValues = new Dictionary<string, string>();
			keyValues.Add("Target", target);
			keyValues.Add("Message", message);
			eventAggregator.GetEvent<EventMessage>().Publish(keyValues);
		}
	}
}
