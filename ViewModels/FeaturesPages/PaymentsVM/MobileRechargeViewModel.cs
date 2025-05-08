using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace bank_demo.ViewModels.FeaturesPages.PaymentsVM
{
    public partial class MobileRechargeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mobileNumber;

        [ObservableProperty]
        private string selectedOperator;

        [ObservableProperty]
        private string amount;

        public ObservableCollection<string> Operators { get; set; }

        public ICommand RechargeCommand { get; }

        public MobileRechargeViewModel()
        {
            Operators = new ObservableCollection<string>
            {
                "Jio", "Airtel", "Vi", "BSNL"
            };

            RechargeCommand = new AsyncRelayCommand(PerformRechargeAsync);
        }

        private async Task PerformRechargeAsync()
        {
            if (string.IsNullOrWhiteSpace(MobileNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid mobile number.", "OK");
                return;
            }

            if (MobileNumber.Length != 10 || !long.TryParse(MobileNumber, out _))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Mobile number must be 10 digits.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(SelectedOperator))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select an operator.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Amount) || !decimal.TryParse(Amount, out decimal rechargeAmount) || rechargeAmount <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid recharge amount.", "OK");
                return;
            }

            // Success message
            await Application.Current.MainPage.DisplayAlert("Success", $"Recharge of ₹{rechargeAmount} to {MobileNumber} via {SelectedOperator} initiated.", "OK");

            // Navigate back to PaymentsPage
            await Shell.Current.GoToAsync("PaymentsPage");
        }
    }
}