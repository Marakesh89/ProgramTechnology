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

            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner} {account2.Balance} {account2.Number}");

            account1.MakeDeposite(12000, DateTime.UtcNow, ";)");
            Console.WriteLine($"Balance: {account1.Balance}");

            account1.MakeWithdrawal(123, DateTime.UtcNow, ";)");
            Console.WriteLine($"Balance: {account1.Balance}");

            try
            {
                account2.MakeWithdrawal(10000, DateTime.UtcNow, "asdas");

            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
