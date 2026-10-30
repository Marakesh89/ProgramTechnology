namespace BankAccounts.Core.Withdrawals;

// Политика с овердрафтом: разрешаем, но берем комиссию
public sealed class OverdraftFeeWithDrawalPolicy : IWithdrawalPolicy
{
    private readonly decimal _fee;
    public OverdraftFeeWithDrawalPolicy(decimal fee) => _fee = fee;    

    public WithdrawalDecision Evaluate(decimal currentBalalnce, decimal amount, decimal minimumBalance)
    => currentBalalnce - amount < minimumBalance 
        ? WithdrawalDecision.AllowWithFee(_fee) 
        : WithdrawalDecision.Allow();
}
