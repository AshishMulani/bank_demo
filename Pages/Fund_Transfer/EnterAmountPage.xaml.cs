using Microsoft.Maui.Controls;
using System;
using bank_demo.ViewModels.FeaturesPages.FundTransfer;

namespace bank_demo.Pages.Fund_Transfer;

[QueryProperty(nameof(BeneficiaryName), "BeneficiaryName")]
[QueryProperty(nameof(AccountType), "AccountType")]
public partial class EnterAmountPage : ContentPage
{
    public EnterAmountPage()
    {
        InitializeComponent();
        BindingContext = new EnterAmountViewModel();

    }

    public string BeneficiaryName
    {
        set => ((ViewModels.FeaturesPages.FundTransfer.EnterAmountViewModel)BindingContext).BeneficiaryName = Uri.UnescapeDataString(value);
    }

    public string AccountType
    {
        set => ((ViewModels.FeaturesPages.FundTransfer.EnterAmountViewModel)BindingContext).AccountType = Uri.UnescapeDataString(value);
    }

    /*private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//FundTransferPage");
    }*/
    protected override bool OnBackButtonPressed()
    {
        // Always navigate to HomePage using Shell absolute route
        Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//FundTransferPage");
        });
        return true; // Prevent default back navigation
    }



}
