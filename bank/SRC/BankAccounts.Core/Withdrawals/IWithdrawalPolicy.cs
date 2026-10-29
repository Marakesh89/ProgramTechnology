namespace BankAccounts.Core.Withdrawals;

public interface IWithdrawalPolicy
{
    WithdrawalDecision Evaluate(decimal currentBalalnce, decimal amount, decimal minimumBalance);
}
