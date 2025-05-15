using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using bank_demo.Services;

namespace bank_demo.ViewModels.FeaturesPages.PaymentsVM
{
    public partial class MobileRechargeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mobileNumber;

        [ObservableProperty]
        private string selectedOperator;

        [ObservableProperty]
        private string selectedCircle;

        [ObservableProperty]
        private string selectedPlanDetails;

        [ObservableProperty]
        private string selectedPlanAmount;

        [ObservableProperty]
        private bool isOperatorVisible;

        [ObservableProperty]
        private bool isCircleVisible;

        public ObservableCollection<string> Operators { get; set; }
        public ObservableCollection<string> Circles { get; set; }

        public ObservableCollection<RechargePlanGroup> GroupedPlans { get; set; }

        public ICommand VerifyNumberCommand { get; }
        public ICommand BrowsePlansCommand { get; }
        public ICommand RechargeCommand { get; }

        public MobileRechargeViewModel()
        {
            Operators = new ObservableCollection<string> { "Jio", "Airtel", "Vi", "BSNL" };
            Circles = new ObservableCollection<string> { "Maharashtra Goa", "Delhi NCR", "Tamil Nadu" };

            GroupedPlans = new ObservableCollection<RechargePlanGroup>
            {
                new RechargePlanGroup("Daily Data", new List<RechargePlan>
                {
                    new RechargePlan("₹199 - 1.5GB/day - 28 days", "₹199"),
                    new RechargePlan("₹249 - 2GB/day - 28 days", "₹249"),
                    new RechargePlan("₹299 - 2.5GB/day - 28 days", "₹299")
                }),
                new RechargePlanGroup("Long Term", new List<RechargePlan>
                {
                    new RechargePlan("₹666 - 1.5GB/day - 84 days", "₹666"),
                    new RechargePlan("₹719 - 2GB/day - 84 days", "₹719")
                }),
                new RechargePlanGroup("Top-up", new List<RechargePlan>
                {
                    new RechargePlan("₹10 - Talktime ₹7.47", "₹10"),
                    new RechargePlan("₹100 - Talktime ₹81.75", "₹100")
                }),
            };

            VerifyNumberCommand = new AsyncRelayCommand(VerifyNumberAsync);
            BrowsePlansCommand = new AsyncRelayCommand(BrowsePlansAsync);
            RechargeCommand = new AsyncRelayCommand(PerformRechargeAsync);
        }

        private async Task BrowsePlansAsync()
        {
            // Flatten the list of all plans
            var allPlans = GroupedPlans.SelectMany(g => g).ToList();
            string selectedPlanDescription = await Application.Current.MainPage.DisplayActionSheet("Select a Plan", "Cancel", null, allPlans.Select(p => p.Description).ToArray());

            if (selectedPlanDescription != null && selectedPlanDescription != "Cancel")
            {
                // Find the selected plan by description
                var selectedPlan = allPlans.FirstOrDefault(p => p.Description == selectedPlanDescription);

                if (selectedPlan != null)
                {
                    SelectedPlanAmount = selectedPlan.Amount;  // Set the amount when the plan is selected
                }
            }
        }

        private async Task VerifyNumberAsync()
        {
            if (string.IsNullOrWhiteSpace(MobileNumber) || MobileNumber.Length != 10 || !long.TryParse(MobileNumber, out _))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid 10-digit mobile number.", "OK");
                return;
            }

            // Auto-detect operator and circle (simulate logic)
            SelectedOperator = "Airtel";
            SelectedCircle = "Maharashtra Goa";

            IsOperatorVisible = true;
            IsCircleVisible = true;
        }

        

        private async Task PerformRechargeAsync()
        {
            if (string.IsNullOrWhiteSpace(MobileNumber) || string.IsNullOrWhiteSpace(SelectedOperator)
                || string.IsNullOrWhiteSpace(SelectedCircle) || string.IsNullOrWhiteSpace(SelectedPlanAmount))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please complete all fields and select a plan before proceeding.", "OK");
                return;
            }


            // Ask for MTPIN or OTP (simulate with prompt)
            string mtpin = await Application.Current.MainPage.DisplayPromptAsync("Enter MTPIN", "Confirm your transaction with MTPIN", "Proceed", "Cancel", "Enter MTPIN", 6, Keyboard.Numeric);

            if (string.IsNullOrWhiteSpace(mtpin))
                return;

            TransactionStore.AllTransactions.Add(new TransactionModel
    {
        Description = $"Recharge to {MobileNumber} ({SelectedOperator})",
        Amount = decimal.Parse(SelectedPlanAmount.TrimStart('₹')),
        Date = DateTime.Now
    });

            // Simulate recharge
            await Application.Current.MainPage.DisplayAlert("Recharge Successful", $"Recharge of {SelectedPlanAmount} for {MobileNumber} completed.", "OK");

            MobileNumber = string.Empty;
            SelectedOperator = null;
            SelectedCircle = null;
            SelectedPlanAmount = string.Empty;
            IsOperatorVisible = false;
            IsCircleVisible = false;



            await Application.Current.MainPage.Navigation.PopAsync();

        }
    }

    public class RechargePlan
    {
        public string Description { get; set; }
        public string Amount { get; set; }

        public RechargePlan(string description, string amount)
        {
            Description = description;
            Amount = amount;
        }
    }

    public class RechargePlanGroup : ObservableCollection<RechargePlan>
    {
        public string GroupName { get; private set; }

        public RechargePlanGroup(string groupName, IEnumerable<RechargePlan> plans) : base(plans)
        {
            GroupName = groupName;
        }
    }
}
