namespace BankAccounts.Core.Withdrawals;


/*политика по умолчанию: если баланс ниже минимума - отклоняем*/
public sealed class StricWithdrawalPolicy : IWithdrawalPolicy
{
    public WithdrawalDecision Evaluate(decimal currentBalalnce, decimal amount, decimal minimumBalance)
        => currentBalalnce - amount < minimumBalance
        ? WithdrawalDecision.Reject("Not sufficient rubls for this withdrawal")
        : WithdrawalDecision.Allow();

}
