using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using bank_demo.Pages.PaymentsFolder;

namespace bank_demo.ViewModels.FeaturesPages
{
    public partial class PaymentsViewModel : ObservableObject
    {
        public ICommand ContactCommand { get; }
        /*public ICommand UPICommand { get; }
        public ICommand DTHCommand { get; }
        public ICommand HomeRentCommand { get; }
        public ICommand LPGCommand { get; }
        public ICommand MobileRechargeCommand { get; }
        public ICommand ElectricityCommand { get; }
        public ICommand FastagCommand { get; }*/

        public PaymentsViewModel()
        {
            ContactCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(ContactPage));
            });
            /*UPICommand = new AsyncRelayCommand(NavigateToUPIPage);
            DTHCommand = new AsyncRelayCommand(NavigateToDTHPage);
            HomeRentCommand = new AsyncRelayCommand(NavigateToHomeRentPage);
            LPGCommand = new AsyncRelayCommand(NavigateToLPGPage);
            MobileRechargeCommand = new AsyncRelayCommand(NavigateToMobileRechargePage);
            ElectricityCommand = new AsyncRelayCommand(NavigateToElectricityPage);
            FastagCommand = new AsyncRelayCommand(NavigateToFastagPage);*/
        }

        /*private Task NavigateToContactPage() => Shell.Current.GoToAsync(nameof(ContactPage));
        private Task NavigateToUPIPage() => Shell.Current.GoToAsync(nameof(UPIPage));
        private Task NavigateToDTHPage() => Shell.Current.GoToAsync(nameof(DTHPage));
        private Task NavigateToHomeRentPage() => Shell.Current.GoToAsync(nameof(HomeRentPage));
        private Task NavigateToLPGPage() => Shell.Current.GoToAsync(nameof(LPGPage));
        private Task NavigateToMobileRechargePage() => Shell.Current.GoToAsync(nameof(MobileRechargePage));
        private Task NavigateToElectricityPage() => Shell.Current.GoToAsync(nameof(ElectricityPage));
        private Task NavigateToFastagPage() => Shell.Current.GoToAsync(nameof(FastagPage));*/
    }
}
