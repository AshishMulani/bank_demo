using Microsoft.Maui.Controls;
using bank_demo.Models;
using bank_demo.ViewModels.FeaturesPages.FundTransfer;

namespace bank_demo.Pages.Fund_Transfer;

public partial class EnterAmountPage : ContentPage
{
    

    public EnterAmountPage(Beneficiary beneficiary)
    {
        InitializeComponent();
        BindingContext = beneficiary; 
        // You can now bind SelectedBeneficiary properties to UI elements on the EnterAmountPage
    }
}

