namespace BankAccounts.Core.Transactions;
 // Простой DTO (date transfer object): сумма, дата примечание
public sealed record Transaction(decimal Amount, DateTime Date, string Note);
