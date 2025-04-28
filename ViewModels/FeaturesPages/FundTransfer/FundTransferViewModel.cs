using System.Collections.ObjectModel;
using System.Windows.Input;
using bank_demo.Pages.Fund_Transfer;
using bank_demo.Services;

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
            // Initialize the Beneficiary list
            Beneficiaries = new ObservableCollection<Beneficiary>
            {
                new Beneficiary { Name = "Amit", Description = "Savings Account" },
                new Beneficiary { Name = "Priya", Description = "Salary Account" }
            };

            // Commands setup
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
                if (!string.IsNullOrEmpty(BeneficiaryName))
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

                    await Shell.Current.GoToAsync($"EnterAmountPage?BeneficiaryName={BeneficiaryName}&AccountType={AccountType}");

                    // Use GoToAsync with proper route and query parameters
                    
                }
            });

            BeneficiaryTappedCommand = new Command<Beneficiary>(async (selectedBeneficiary) =>
            {
                if (selectedBeneficiary != null)
                {
                    // Use Shell.Current.GoToAsync with query parameters properly
                    var queryParams = new Dictionary<string, string>
                    {
                        { "BeneficiaryName", selectedBeneficiary.Name },
                        { "AccountType", selectedBeneficiary.Description }
                    };

                    // Use GoToAsync with proper route and query parameters
                    await Shell.Current.GoToAsync("EnterAmountPage?BeneficiaryName={BeneficiaryName}&AccountType={AccountType}");
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
