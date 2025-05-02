namespace bank_demo.Pages.Fund_Transfer;

public partial class FundTransferPage : ContentPage
{
    public FundTransferPage()
    {
        InitializeComponent();

    }
    protected override bool OnBackButtonPressed()
    {
        // Navigate asynchronously without awaiting directly
        Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//Home");
        });

        return true; // Prevent default back navigation
    }


}


