using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{

    /// <summary>
    /// Представляет сберегательный счёт с начислением процентов на остаток.
    /// </summary>
    public class InteresEarningAccount:BankAccount
    {

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InteresEarningAccount"/>.
        /// </summary>
        /// <param name="name">Имя владельца счёта.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        public InteresEarningAccount(string name, decimal initialBalance)
            :base(name, initialBalance)
        {

        }

        // override позволяет в дочернем классе определить в новую реализацию  
        // метода PerformMouthAndTransactions

        /// <summary>
        /// Начисляет ежемесячные проценты на остаток, если баланс превышает 500.
        /// </summary>
        public override void PerformMouthAndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposite(interest, DateTime.UtcNow, "Apply mouth interest", TransactionType.Interest);
            }
        }
    }
}
