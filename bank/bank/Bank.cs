namespace ConsoleApp1
{
    public class Bank
    {
        public void Transfer(BankAccount from, BankAccount to, decimal amount)
        {
            ArgumentNullException.ThrowIfNull(from);
            ArgumentNullException.ThrowIfNull(to);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

            if (ReferenceEquals(from, to))
            {
                throw new InvalidOperationException(
                    "Cannot transfer money to the same account.");
            }

            if (from.Balance - amount < from.MinimalBalance)
            {
                throw new InvalidOperationException(
                    "Not sufficient funds for this transfer.");
            }

            Guid transferId = Guid.NewGuid();
            DateTime transferDate = DateTime.UtcNow;

            from.MakeWithdrawal(
                amount,
                transferDate,
                "Transfer to account " + to.Number,
                TransactionType.Withdrawal,
                transferId);

            to.MakeDeposite(
                amount,
                transferDate,
                "Transfer from account " + from.Number,
                TransactionType.Deposit,
                transferId);
        }
    }
}