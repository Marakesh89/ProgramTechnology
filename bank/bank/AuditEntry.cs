namespace ConsoleApp1
{
    public class AuditEntry
    {
        public string AccountNumber { get; }
        public TransactionType Type { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        public AuditEntry(string accountNumber, TransactionType type, decimal amount, DateTime date)
        {
            AccountNumber = accountNumber;
            Type = type;
            Amount = amount;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date}: Account {AccountNumber}, {Type}, Amount: {Amount}";
        }
    }
}