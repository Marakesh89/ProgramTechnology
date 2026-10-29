namespace BankAccounts.Core.AccountNumbers;

// Геренрация номеров - отдельна ответственность, не должна быть внутри счета (SRP)
public interface IAccountNumberGenerator
{
    string Next();
}
