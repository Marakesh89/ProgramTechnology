using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    public class InteresEarningAccount:BankAccount
    {
        public InteresEarningAccount(string name, decimal initialBalance)
            :base(name, initialBalance)
        {

        }

        // override позволяет в дочернем классе определить в новую реализацию  
        // метода PerformMouthAndTransactions
        public override void PerformMouthAndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposite(interest, DateTime.UtcNow, "Apply mouth interest");
            }
        }
    }
}
