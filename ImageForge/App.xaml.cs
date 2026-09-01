using System.Windows;
using ImageForge.ViewModels;
using ImageForge.Views;
using Prism.Ioc;

namespace ImageForge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TopView,TopViewModel>("TopView");
            containerRegistry.RegisterForNavigation<ContentView,ContentViewModel>("ContentView");
            containerRegistry.RegisterForNavigation<BottomView,BottomViewModel>("BottomView");
		}
    }
}
