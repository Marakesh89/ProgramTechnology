using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace bank;

public class LineOfCreditAccount: BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance,decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
    {

    }

    public override void PerformMouthAndTransactions()
    {
          if (Balance < 0)
        {
            decimal interes = -Balance * 0.07m;
            MakeWithdrawal(interes, DateTime.UtcNow, "Change monthly interes");
        }
    }

    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;
}
