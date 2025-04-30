using System.Windows.Input;
using bank_demo.Services;

namespace bank_demo.ViewModels.FeaturesPages.FundTransfer
{
    public class EnterAmountViewModel : BaseViewModel
    {
        private string _beneficiaryName;
        public string BeneficiaryName
        {
            get => _beneficiaryName;
            set => SetProperty(ref _beneficiaryName, value);
        }

        private string _accountType;
        public string AccountType
        {
            get => _accountType;
            set => SetProperty(ref _accountType, value);
        }

        private string _amount;
        public string Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        private string _remarks;
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        private string _selectedTransferOption;
        public string SelectedTransferOption
        {
            get => _selectedTransferOption;
            set => SetProperty(ref _selectedTransferOption, value);
        }

        public List<string> TransferOptions { get; } = new List<string> { "NEFT", "IMPS" };


        public ICommand ProceedCommand { get; }

        public EnterAmountViewModel()
        {
            ProceedCommand = new Command(OnProceed);
            SelectedTransferOption = TransferOptions.First();
        }

        private async void OnProceed()
        {
            if (string.IsNullOrEmpty(Amount))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter an amount", "OK");
                return;
            }

            //await Shell.Current.GoToAsync("ConfirmationPage"); // Replace with real route

            string summary = $"Name: {BeneficiaryName}\nAccount Type: {AccountType}\nAmount: ₹{Amount}\nRemarks: {Remarks}\nTransfer Mode: {SelectedTransferOption}";

            bool confirm = await Shell.Current.DisplayAlert("Confirm Transfer", summary, "Proceed", "Cancel");

            if (confirm)
            {
                // Proceed to next page or complete transaction
                await Shell.Current.DisplayAlert("Success", "Transfer Initiated", "OK");
                if (Shell.Current.Navigation.NavigationStack.Count > 1)
                {
                    // Make sure we are not directly on the root page.
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    // Handle root navigation if necessary, for example, navigate back to the home screen.
                    await Shell.Current.GoToAsync("Home");
                }

            }
        }



    }
}
