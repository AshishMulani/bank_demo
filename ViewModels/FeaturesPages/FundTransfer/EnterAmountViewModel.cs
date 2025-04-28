using bank_demo.Models;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using bank_demo.Pages.Fund_Transfer;

namespace bank_demo.ViewModels.FeaturesPages.FundTransfer
{
    public class EnterAmountViewModel : BaseViewModel
    {
        public string BeneficiaryName { get; set; }
        public string AccountType { get; set; }
        public decimal Amount { get; set; }

        public Beneficiary SelectedBeneficiary { get; set; }

        public ICommand ContinueCommand { get; }

        public EnterAmountViewModel(Beneficiary beneficiary)
        {
            SelectedBeneficiary = beneficiary;
            BeneficiaryName = beneficiary?.Name;
            AccountType = beneficiary?.Description;

            ContinueCommand = new Command(OnContinue);
        }

        private async void OnContinue()
        {
            if (Amount <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid amount", "OK");
                return;
            }

            // Navigate to transfer method page
            await Application.Current.MainPage.Navigation.PushAsync(new TransferMethodPage(SelectedBeneficiary, Amount));
        }
    }
}
