using System.Collections.ObjectModel;
using bank_demo.Services;
using System.Linq;

namespace bank_demo.ViewModels.FeaturesPages
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<GroupedTransaction> Transactions { get; set; }

        public HistoryViewModel()
        {
            // Initialize the ObservableCollection for transactions
            Transactions = new ObservableCollection<GroupedTransaction>();

            // Add some sample transactions for testing
            var allTransactions = new List<TransactionModel>
            {
                new TransactionModel { Description = "Payment to Rahul", Amount = 500, Date = DateTime.Today, Icon = "toll.png" },
                new TransactionModel { Description = "Refund from Amazon", Amount = 1200, Date = DateTime.Today, Icon = "toll.png" },
                new TransactionModel { Description = "Dinner with Friends", Amount = 850, Date = DateTime.Today.AddDays(-1), Icon = "toll.png" },
                new TransactionModel { Description = "Movie Tickets", Amount = 600, Date = DateTime.Today.AddDays(-3), Icon = "toll.png" }
            };

            // Group the transactions based on their dates
            var todayTransactions = new ObservableCollection<TransactionModel>();
            var yesterdayTransactions = new ObservableCollection<TransactionModel>();
            var earlierTransactions = new ObservableCollection<TransactionModel>();

            foreach (var txn in allTransactions)
            {
                if (txn.Date.Date == DateTime.Today)
                    todayTransactions.Add(txn);
                else if (txn.Date.Date == DateTime.Today.AddDays(-1))
                    yesterdayTransactions.Add(txn);
                else
                    earlierTransactions.Add(txn);
            }

            // Add grouped transactions
            if (todayTransactions.Any())
            {
                Transactions.Add(new GroupedTransaction("Today", todayTransactions));
                Console.WriteLine("Added transactions for Today.");
            }

            if (yesterdayTransactions.Any())
            {
                Transactions.Add(new GroupedTransaction("Yesterday", yesterdayTransactions));
                Console.WriteLine("Added transactions for Yesterday.");
            }

            if (earlierTransactions.Any())
            {
                Transactions.Add(new GroupedTransaction("Earlier", earlierTransactions));
                Console.WriteLine("Added transactions for Earlier.");
            }
        }
    }
}
