using bank_demo.Pages;
using bank_demo.Pages.Fund_Transfer;
using bank_demo.Pages.PaymentsFolder;

namespace bank_demo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register all your routes
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("Signup", typeof(SignupPage));
        Routing.RegisterRoute("ForgotPasswordPage", typeof(ForgotPasswordPage));
        Routing.RegisterRoute("Home", typeof(HomePage));
        Routing.RegisterRoute("About", typeof(About));
        Routing.RegisterRoute("Settings", typeof(Settings));

        Routing.RegisterRoute(nameof(MyQRCodePage), typeof(MyQRCodePage));
        Routing.RegisterRoute(nameof(ScanToPayPage), typeof(ScanToPayPage));
        Routing.RegisterRoute(nameof(StatementPage), typeof(StatementPage));
        Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
        Routing.RegisterRoute(nameof(AddBeneficiaryPage), typeof(AddBeneficiaryPage));
        Routing.RegisterRoute(nameof(PaymentsPage), typeof(PaymentsPage));
        // Log navigation to PaymentsPage
        this.Navigating += (s, e) =>
        {
            if (e.Target.Location.OriginalString.Contains(nameof(PaymentsPage)))
            {
                Console.WriteLine($"Navigating to: {e.Target.Location}");
            }
        };
        this.Navigated += (s, e) =>
        {
            if (e.Current.Location.OriginalString.Contains(nameof(PaymentsPage)))
            {
                Console.WriteLine($"Navigated to: {e.Current.Location}");
            }
        };
        Routing.RegisterRoute(nameof(FundTransferPage), typeof(FundTransferPage));


        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(TransactionHistoryPage), typeof(TransactionHistoryPage));
        Routing.RegisterRoute(nameof(BeneficiaryStatusPage), typeof(BeneficiaryStatusPage));
        Routing.RegisterRoute(nameof(ContactSupportPage), typeof(ContactSupportPage));
        Routing.RegisterRoute(nameof(SecuritySettingsPage), typeof(SecuritySettingsPage));
        Routing.RegisterRoute(nameof(TermsPage), typeof(TermsPage));


        
        // Register route for navigation
        Routing.RegisterRoute(nameof(EnterAmountPage), typeof(EnterAmountPage));

        // Register route for Payments options
        Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
        Routing.RegisterRoute(nameof(SendMoneyPage), typeof(SendMoneyPage));
        Routing.RegisterRoute(nameof(MobileRechargePage), typeof(MobileRechargePage));




        // Navigate to LoginPage after AppShell is loaded
        Dispatcher.Dispatch(async () =>
        {
            await GoToAsync("//LoginPage");
        });
    }
    // Logout handler
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }
    
  


}
