using bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Danil", 10000000);
            BankAccount account2 = new BankAccount("Ulyana", 1000);

            Console.WriteLine($"{account1.Owner}   {account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner}   {account2.Balance} {account2.Number}");

            account1.MakeDeposite(12000, DateTime.UtcNow, ";)");
            Console.WriteLine($"Balance: {account1.Balance}");

            account1.MakeWithdrawal(123, DateTime.UtcNow, ";)");
            Console.WriteLine($"Balance: {account1.Balance}");
            Console.WriteLine(account1.GetAccountHistory());

            try
            {
                account2.MakeWithdrawal(10000, DateTime.UtcNow, "asdas");

            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            InteresEarningAccount interes = new InteresEarningAccount("Dany", 20000);
            interes.PerformMouthAndTransactions();

            Console.WriteLine(interes.GetAccountHistory());

            LineOfCreditAccount lineOfCredit = new LineOfCreditAccount("Dany", 0, 1000m);
            lineOfCredit.MakeWithdrawal(500m, DateTime.UtcNow, "Credit");

            GiftCartAccount giftCart = new GiftCartAccount("Dany", 3000m, 5000m);

            List <BankAccount> accounts = new List<BankAccount>();
            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(lineOfCredit);
            accounts.Add(giftCart);

            foreach (BankAccount account in accounts)
            {
                //Console.WriteLine(account.ToString());
                Console.WriteLine(account);
                account.PerformMouthAndTransactions();
                Console.WriteLine(account.GetAccountHistory());
            }

            lineOfCredit.MakeWithdrawal(600m, DateTime.UtcNow, "credit");
            Console.WriteLine(lineOfCredit.GetAccountHistory());

        }
    }
}
