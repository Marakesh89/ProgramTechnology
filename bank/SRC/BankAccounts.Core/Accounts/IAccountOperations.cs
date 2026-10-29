namespace BankAccounts.Core.Accounts;

public interface IAccountOperations
{
    decimal Balance { get; }
    void Deposit(decimal amount, DateTime date, string note);
    void WithDraw(decimal amount, DateTime date, string note);
}
