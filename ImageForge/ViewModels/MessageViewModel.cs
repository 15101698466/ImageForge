using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageForge.ViewModels
{
	public class MessageViewModel :BindableBase, IDialogAware
	{

		private string strTitle;

		public string StrTitle
		{
			get { return strTitle; }
			set { strTitle = value; RaisePropertyChanged(); }
		}


		public DelegateCommand YesCommand { get; set; }
		public DelegateCommand CancelCommnd {  get; set; }

		public MessageViewModel() 
		{
			YesCommand = new DelegateCommand(YesClick);
			CancelCommnd = new DelegateCommand(CancelWindow);
		}

		private void CancelWindow()
		{
			var result = new DialogResult(ButtonResult.Cancel);
			RequestClose.Invoke(result);
		}

		private void YesClick()
		{

			var result = new DialogResult(ButtonResult.Yes);
			RequestClose.Invoke(result);
		}

		public DialogCloseListener RequestClose { get; }

		public bool CanCloseDialog()
		{
			return true;
		}

		public void OnDialogClosed()
		{
			
		}

		public void OnDialogOpened(IDialogParameters parameters)
		{
			if (parameters != null)
			{
				StrTitle = parameters["message"].ToString();
			}
		}
	}
}
