using Prism.Mvvm;
using Prism.Navigation.Regions;
using System.Threading.Tasks;

namespace ImageForge.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private IRegionManager regionManager;
		private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager region)
        {
            regionManager = region;
            LoadView();

		}

        private async Task LoadView()
        {
            await Task.Delay(1000);
			regionManager.RequestNavigate("TopRegion", "TopView");
			regionManager.RequestNavigate("ContentRegion","ContentView");
			regionManager.RequestNavigate("BottomRegion", "BottomView");
		}
    }
}
