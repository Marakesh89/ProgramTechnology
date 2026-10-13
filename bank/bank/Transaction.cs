using System.Data;


namespace ConsoleApp1;


/// <summary>
/// Представляет банковскую транзакцию.
/// </summary>
/// <param name="Amount">Сумма транзакции.</param>
/// <param name="Date">Дата транзакции.</param>
/// <param name="Note">Комментарий к транзакции.</param>
public record Transaction(decimal Amount, DateTime Date, string Note)
{
    public Guid? TransferId { get; init; }
}
