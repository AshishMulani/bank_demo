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

    protected override bool OnBackPressed()
    {
        // Ensure the back button does what it needs to do
        Shell.Current.Navigation.PopAsync();
        return true;  // Prevents the default back behavior (which might be blocked)
    }

}
