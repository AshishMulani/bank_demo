using bank_demo.ViewModels.FeaturesPages;
using bank_demo.Services;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace bank_demo.Pages;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
		BindingContext = new HistoryViewModel();

    }

    

}