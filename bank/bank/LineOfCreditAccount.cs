using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace bank;

/// <summary>
/// Представляет кредитный счёт с лимитом и начислением процентов.
/// </summary>
public class LineOfCreditAccount: BankAccount
{

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LineOfCreditAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс счёта.</param>
    /// <param name="creditLimit">Кредитный лимит.</param>
    public LineOfCreditAccount(string name, decimal initialBalance,decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
    {

    }


    /// <summary>
    /// Начисляет ежемесячные проценты при отрицательном балансе.
    /// </summary>
    public override void PerformMouthAndTransactions()
    {
          if (Balance < 0)
        {
            decimal interes = -Balance * 0.07m;
            MakeWithdrawal(interes, DateTime.UtcNow, "Change monthly interes", TransactionType.Interest);
        }
    }



    /// <summary>
    /// Проверяет, допустимо ли снятие с учётом кредитного лимита.
    /// </summary>
    /// <param name="isOverdrawn">Признак того, что баланс уходит ниже минимального.</param>
    /// <returns>Транзакция штрафа за овердрафт или <c>null</c>, если штраф не требуется.</returns>
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;
}
