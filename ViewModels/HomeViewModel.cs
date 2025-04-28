using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls; // ✅ For Command
using System.Windows.Input;
using bank_demo.Pages;
using bank_demo.Pages.Fund_Transfer;

namespace bank_demo.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _customerName = "Ashish Mulani";
        public string CustomerName
        {
            get => _customerName;
            set { _customerName = value; OnPropertyChanged(); }
        }

        private decimal _savingsBalance = 12500.75m;
        public decimal SavingsBalance
        {
            get => _savingsBalance;
            set { _savingsBalance = value; OnPropertyChanged(); }
        }

        private bool _isMenuVisible;
        public bool IsMenuVisible
        {
            get => _isMenuVisible;
            set
            {
                if (_isMenuVisible != value)
                {
                    _isMenuVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        // General Commands
        public ICommand AboutCommand { get; }
        public ICommand HomeCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand QRCommand { get; }
        public ICommand ScanToPayCommand { get; }
        public ICommand StatementCommand { get; }
        public ICommand HistoryCommand { get; }
        public ICommand AddBeneficiaryCommand { get; }
        public ICommand PaymentsCommand { get; }
        public ICommand FundTransferCommand { get; }

        // Menu Drawer Commands
        public ICommand ProfileCommand { get; }
        public ICommand TransactionHistoryCommand { get; }
        public ICommand BeneficiaryStatusCommand { get; }
        public ICommand ContactSupportCommand { get; }
        public ICommand SecuritySettingsCommand { get; }
        public ICommand TermsConditionsCommand { get; }
        public ICommand LogoutCommand { get; }

        // Toggle Drawer Menu Visibility
        public ICommand ToggleMenuCommand { get; }

        public HomeViewModel()
        {
            AboutCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("About");
            });

            HomeCommand = new Command(async () =>
            {
                await Shell.Current.DisplayAlert("Home", "Already on Home page", "OK");
            });

            SettingsCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("Settings");
            });

            QRCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(MyQRCodePage));
            });

            ScanToPayCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(ScanToPayPage));
            });

            StatementCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(StatementPage));
            });

            HistoryCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(HistoryPage));
            });

            AddBeneficiaryCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(AddBeneficiaryPage));
            });

            PaymentsCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(PaymentsPage));
            });

            FundTransferCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(FundTransferPage));
            });

            // Drawer Commands
            ProfileCommand = new Command(async () => await GoToPage(nameof(ProfilePage)));
            TransactionHistoryCommand = new Command(async () => await GoToPage(nameof(TransactionHistoryPage)));
            BeneficiaryStatusCommand = new Command(async () => await GoToPage(nameof(BeneficiaryStatusPage)));
            ContactSupportCommand = new Command(async () => await GoToPage(nameof(ContactSupportPage)));
            SecuritySettingsCommand = new Command(async () => await GoToPage(nameof(SecuritySettingsPage)));
            TermsConditionsCommand = new Command(async () => await GoToPage(nameof(TermsPage)));
            LogoutCommand = new Command(async () =>
            {
                // Optional: Clear user session data here
                await Shell.Current.GoToAsync("//LoginPage");
            });

            // Toggle drawer visibility
            ToggleMenuCommand = new Command(() => IsMenuVisible = !IsMenuVisible);
        }

        private async Task GoToPage(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
