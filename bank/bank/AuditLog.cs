using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class AuditLog
    {
        private readonly List<AuditEntry> _entries = new List<AuditEntry>();

        public void Log(string accountNumber, TransactionType type, decimal amount, DateTime date)
        {
            AuditEntry entry = new AuditEntry(accountNumber, type, amount, date);
            _entries.Add(entry);
        }

        public void PrintLog()
        {
            foreach (AuditEntry entry in _entries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}