using Microsoft.Maui.Controls;
using System;
using bank_demo.ViewModels.FeaturesPages;
using bank_demo.Pages.Fund_Transfer;
using bank_demo.Models;

namespace bank_demo.Pages;

public partial class AddBeneficiaryPage : ContentPage
{
    private readonly bool _fromFundTransfer;
    public AddBeneficiaryPage(bool fromFundTransferPage = false)
    {
        InitializeComponent();
        BindingContext = new AddBeneficiaryViewModel();
        _fromFundTransfer = fromFundTransferPage;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Save beneficiary logic here

        var newBeneficiary = new Beneficiary
        {
            Name = "Sample Name",         // You can replace it with real form data
            Description = "Savings Account" // Replace with real form data
        };

        if (_fromFundTransfer)
        {
            await Navigation.PushAsync(new EnterAmountPage(newBeneficiary));
        }
        else
        {
            await DisplayAlert("Success", "Beneficiary added", "OK");
            await Navigation.PopAsync();
        }
    }

    }

