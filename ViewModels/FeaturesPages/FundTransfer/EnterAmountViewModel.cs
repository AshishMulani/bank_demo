using System.Windows.Input;
using Microsoft.Maui.Controls;
using bank_demo.Services;

namespace bank_demo.ViewModels.FeaturesPages.FundTransfer
{
    public class EnterAmountViewModel : BaseViewModel
    {
        public string BeneficiaryName { get; set; }
        public string AccountType { get; set; }
        public decimal Amount { get; set; }

        public Beneficiary SelectedBeneficiary { get; set; }

        public ICommand ContinueCommand { get; }
        public ICommand BackCommand { get; }

        public EnterAmountViewModel()
        {
            ContinueCommand = new Command(OnContinue);
            BackCommand = new Command(OnBack);
        }

        public EnterAmountViewModel(Beneficiary beneficiary)
        {
            SelectedBeneficiary = beneficiary;
            BeneficiaryName = beneficiary?.Name;
            AccountType = beneficiary?.Description;
        }

        private async void OnContinue()
        {
            if (Amount <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid amount", "OK");
                return;
            }

            // Navigate to the transfer method page
            await Shell.Current.GoToAsync("TransferMethodPage?BeneficiaryName=" + SelectedBeneficiary.Name + "&Amount=" + Amount);
        }

        private async void OnBack()
        {
            // Navigate back to the previous page (FundTransferPage)
            await Shell.Current.GoToAsync("..");
        }
    }
}
