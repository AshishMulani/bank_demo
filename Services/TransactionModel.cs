namespace bank_demo.Services;
    public class TransactionModel
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    //for payments
    public string Id { get; set; }
    public string Type { get; set; } // Contact, UPI, DTH, etc.
    public string Status { get; set; } // Success, Failed, Pending
    public string Recipient { get; set; }
    public string amount { get; set; }


}
