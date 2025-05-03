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
        set => ((EnterAmountViewModel)BindingContext).BeneficiaryName = Uri.UnescapeDataString(value);
    }

    public string AccountType
    {
        set => ((EnterAmountViewModel)BindingContext).AccountType = Uri.UnescapeDataString(value);
    }

    
    
}





