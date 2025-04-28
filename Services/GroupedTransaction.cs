using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bank_demo.Services
{
    public class GroupedTransaction : ObservableCollection<TransactionModel>
    {
        public string GroupTitle { get; set; }

        // Constructor accepts IEnumerable<TransactionModel> to allow flexibility with different collection types
        public GroupedTransaction(string title, IEnumerable<TransactionModel> transactions)
            : base(transactions)
        {
            GroupTitle = title;
        }
    }
}
