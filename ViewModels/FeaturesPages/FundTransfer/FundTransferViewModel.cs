using System.Collections.ObjectModel;
using System.Windows.Input;
using bank_demo.Services;
using bank_demo.Pages.Fund_Transfer;

namespace bank_demo.ViewModels.FeaturesPages.FundTransfer
{
    public class FundTransferViewModel : BaseViewModel
    {
        public ObservableCollection<Beneficiary> Beneficiaries { get; set; }

        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string OfficeName { get; set; }
        public string TransferLimit { get; set; }
        public string BeneficiaryName { get; set; }

        public bool IsListVisible { get; set; } = true;
        public bool IsAddVisible => !IsListVisible;

        public ICommand ShowListCommand { get; }
        public ICommand ShowAddFormCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand BeneficiaryTappedCommand { get; }

        public FundTransferViewModel()
        {
            Beneficiaries = new ObservableCollection<Beneficiary>
            {
                new Beneficiary { Name = "Amit", Description = "Savings Account" },
                new Beneficiary { Name = "Priya", Description = "Salary Account" }
            };

            ShowListCommand = new Command(() =>
            {
                IsListVisible = true;
                OnPropertyChanged(nameof(IsListVisible));
                OnPropertyChanged(nameof(IsAddVisible));
            });

            ShowAddFormCommand = new Command(() =>
            {
                IsListVisible = false;
                OnPropertyChanged(nameof(IsListVisible));
                OnPropertyChanged(nameof(IsAddVisible));
            });

            SubmitCommand = new Command(async () =>
            {
                if (!string.IsNullOrWhiteSpace(BeneficiaryName))
                {
                    var newBeneficiary = new Beneficiary
                    {
                        Name = BeneficiaryName,
                        Description = AccountType
                    };

                    BeneficiaryService.AddBeneficiary(newBeneficiary);
                    Beneficiaries.Add(newBeneficiary);
                    ClearForm();
                    ShowListCommand.Execute(null);

                    await Shell.Current.GoToAsync($"{nameof(EnterAmountPage)}?BeneficiaryName={Uri.EscapeDataString(BeneficiaryName)}&AccountType={Uri.EscapeDataString(AccountType)}");

                }
            });

            BeneficiaryTappedCommand = new Command<Beneficiary>(async (selectedBeneficiary) =>
            {
                if (selectedBeneficiary != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(EnterAmountPage)}?BeneficiaryName={Uri.EscapeDataString(selectedBeneficiary.Name)}&AccountType={Uri.EscapeDataString(selectedBeneficiary.Description)}");

                }
            });
        }

        void ClearForm()
        {
            AccountType = string.Empty;
            AccountNumber = string.Empty;
            OfficeName = string.Empty;
            TransferLimit = string.Empty;
            BeneficiaryName = string.Empty;

            OnPropertyChanged(nameof(AccountType));
            OnPropertyChanged(nameof(AccountNumber));
            OnPropertyChanged(nameof(OfficeName));
            OnPropertyChanged(nameof(TransferLimit));
            OnPropertyChanged(nameof(BeneficiaryName));
        }
    }
}
