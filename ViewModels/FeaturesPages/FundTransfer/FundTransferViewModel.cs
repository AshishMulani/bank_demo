using System.Collections.ObjectModel;
using System.Windows.Input;
using bank_demo.Services;
using bank_demo.Pages.Fund_Transfer;

namespace bank_demo.ViewModels.FeaturesPages.FundTransfer
{
    public class FundTransferViewModel : BaseViewModel
    {
        public ObservableCollection<Beneficiary> Beneficiaries { get; set; }

        public string BeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public int BeneficiaryAccountNumber { get; set; }
        public string Branch { get; set; }
        public string Nickname { get; set; }

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
                new Beneficiary
    {
        Name = "Amit",
        BankName = "Axis Bank",
        IFSCCode = "AXIS0001234",
        BeneficiaryAccountNumber = 123456789,
        Branch = "Connaught Place",
        Nickname = "Ami",
        
    },
    new Beneficiary
    {
        Name = "Priya",
        BankName = "HDFC Bank",
        IFSCCode = "HDFC0005678",
        BeneficiaryAccountNumber = 987654321,
        Branch = "MG Road",
        Nickname = "Pri",
        
    }
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
                        BankName = "Default Bank", 
                        IFSCCode = "DEFAULT000",   
                        BeneficiaryAccountNumber = 12345678, 
                        Branch = "Default Branch", 
                        Nickname = "Nick",         
                        
                    };

                    BeneficiaryService.AddBeneficiary(newBeneficiary);
                    Beneficiaries.Add(newBeneficiary);
                    ClearForm();
                    ShowListCommand.Execute(null);

                    

                }
            });

            BeneficiaryTappedCommand = new Command<Beneficiary>(async (selectedBeneficiary) =>
            {
                if (selectedBeneficiary != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(EnterAmountPage)}?BeneficiaryName={Uri.EscapeDataString(selectedBeneficiary.Name)}&BankName={Uri.EscapeDataString(selectedBeneficiary.BankName)}");

                }
            });
        }

        void ClearForm()
        {
            BeneficiaryName = string.Empty;
            BankName = string.Empty;
            IFSCCode = string.Empty;
            BeneficiaryAccountNumber =0;
            Branch = string.Empty;
            Nickname = string.Empty;

            OnPropertyChanged(nameof(BeneficiaryName));
            OnPropertyChanged(nameof(BankName));
            OnPropertyChanged(nameof(IFSCCode));
            OnPropertyChanged(nameof(BeneficiaryAccountNumber));
            OnPropertyChanged(nameof(Branch));
            OnPropertyChanged(nameof(Nickname));
        }
    }
}
