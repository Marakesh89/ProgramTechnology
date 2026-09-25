using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BankAccount
    {
        private List<Transaction> _allTransactions = new List<Transaction>();
        public string Owner { get; private set; }
        public string Number { get; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transaction in _allTransactions)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }



        private static int s_accountNumberSeed = 1000000000;

        public BankAccount(string name, decimal initialBalance)
        {


            // this.balance = initialBalance;
            MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance");
            Owner = name;
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
        }

        public void MakeDeposite(decimal amout, DateTime date, string note)
        {
            if (amout <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amout), "Amount of deposite must be positive");
            }


            var deposite = new Transaction(amout, date, note);
            _allTransactions.Add(deposite);

        }

        public void MakeWithdrawal(decimal amout, DateTime date, string note)
        {
            if (amout <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amout), "Amount of withdrawal must be positive");
            }

            if (Balance < amout)
            {
                throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
            }
            var deposite = new Transaction(amout, date, note);
            _allTransactions.Add(deposite);
        }
    }
}

