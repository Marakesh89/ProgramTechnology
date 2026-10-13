using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // BankAccount - потомок класс object 

    /// <summary>
    /// Представляет банковский счёт с возможностью пополнения, снятия и получения истории операций
    /// </summary>

    public class BankAccount
    {

        private readonly decimal _minimalBalance;
        public decimal MinimalBalance => _minimalBalance;
        private List<Transaction> _allTransactions = new List<Transaction>();
        private readonly AuditLog _auditLog = new AuditLog();

        /// <summary>
        /// Возвращает имя владельца счёта
        /// </summary>
        public string Owner { get; private set; }

        /// <summary>
        /// Возвращает номер счёта.
        /// </summary>
        public string Number { get; }


        /// <summary>
        /// Возвращает стасут клиента 
        /// </summary>
        public AccountStatus Status { get; private set; }

        /// <summary>
        /// Возвращает текущий баланс счёта
        /// </summary>
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

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с минимальным балансом по умолчанию (0).
        /// </summary>
        /// <param name="name">Имя владельца счёта.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        public BankAccount(string name, decimal initialBalance):this(name, initialBalance, 0)
        {
            
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с минимальным балансом.
        /// </summary>
        /// <param name="name">Имя владельца счёта.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        /// <param name="minimalBalance">Минимально допустимый баланс счета</param>
        public BankAccount(string name, decimal initialBalance, decimal minimalBalance)
    : this(name, initialBalance, minimalBalance, AccountStatus.Regular)
        {
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с указанным статусом клиента.
        /// </summary>
        /// <param name="name">Имя владельца счёта.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        /// <param name="minimalBalance">Минимально допустимый баланс счёта.</param>
        /// <param name="status">Статус клиента: Regular, Premium или VIP.</param>
        public BankAccount(
            string name,
            decimal initialBalance,
            decimal minimalBalance,
            AccountStatus status)
        {
            Owner = name;
            Status = status;

            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            _minimalBalance = minimalBalance;

            if (initialBalance > 0)
            {
                MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance");
            }
        }

        /// <summary>
        /// Пополняет счёт на указанную сумму
        /// </summary>
        /// <param name="amout">Сумма пополнения. Должна быть положительной.</param>
        /// <param name="date">Дата операции.</param>
        /// <param name="note">Комментарий к операции.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="amout"/> меньше или равен нулю.
        /// </exception>
        public void MakeDeposite(decimal amout, DateTime date, string note,
            TransactionType type = TransactionType.Deposit, Guid? transferId = null)
        {
            if (amout <= 0)
                throw new ArgumentOutOfRangeException(nameof(amout), "Amount of deposite must be positive");

            var deposite = new Transaction(amout, date, note)
            {
                TransferId = transferId
            };

            _allTransactions.Add(deposite);
            _auditLog.Log(Number, type, amout, date);
        }
        /// <summary>
        /// Снимает указанную сумму со счёта.
        /// </summary>
        /// <param name="amout">Сумма снятия. Должна быть положительной.</param>
        /// <param name="date">Дата операции.</param>
        /// <param name="note">Комментарий к операции.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="amout"/> меньше или равен нулю.
        /// </exception>
        public void MakeWithdrawal(decimal amout, DateTime date, string note,
            TransactionType type = TransactionType.Withdrawal, Guid? transferId = null)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amout);

            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amout < _minimalBalance);
            Transaction? withdrawal = new(-amout, date, note)
            {
                TransferId = transferId
            };
            _allTransactions.Add(withdrawal);
            _auditLog.Log(Number, type, amout, date);
            if (overdraftTransaction is not null)
            {
                _allTransactions.Add(overdraftTransaction);
                _auditLog.Log(Number, TransactionType.Withdrawal,
                    Math.Abs(overdraftTransaction.Amount), overdraftTransaction.Date);
            }
            if (Status == AccountStatus.VIP)
            {
                decimal cashback = amout * 0.05m;
                MakeDeposite(cashback, date, "VIP cashback");
            }
        }

        

        // protected - модификатор доступа, который означает,
        // что этот метод можно вызвать только из текущего и дочернего класса 
        // Клиент (внешний код) данный метод вызвать не может 

        /// <summary>
        /// Проверяет, допустимо ли снятие с учётом минимального баланса.
        /// </summary>
        /// <param name="isOverdrawn">Признак того, что баланс уходит ниже минимального.</param>
        /// <returns>Транзакция штрафа или <c>null</c>, если штраф не требуется.</returns>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если снятие превышает допустимый лимит.
        /// </exception>
        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient rubls for this withdrawal");

            }
            else
            {
                // default - содержит значение по умолчанию, так как тип возвращаемого значения - ссылочная, то 
                // default = null
                return default; // == return null;
            }

        }

        /// <summary>
        /// Возвращает историю операций по счёту в виде текстового отчёта.
        /// </summary>
        /// <returns>Строка с историей операций.</returns>
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            decimal balance = 0;
            report.AppendLine("Data\t\tAmount\tBalance\tNote\tTransfer ID");
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
                report.AppendLine(
                    $"{item.Date.ToShortDateString()}\t" +
                    $"{item.Amount}\t{balance}\t{item.Note}\t{item.TransferId}");
            }
            return report.ToString();
        }
        // Ключевое слово virtual позволяет в дочернем классе предоставить другую реализацию этого метода 

        /// <summary>
        /// Выполняет ежемесячные операции по счёту.
        /// </summary>
        public virtual void PerformMouthAndTransactions()
        {
            if (Status == AccountStatus.Regular)
            {
                MakeWithdrawal(50, DateTime.UtcNow, "Monthly fee");
            }
            else if (Status == AccountStatus.Premium && Balance > 10000)
            {
                decimal interest = (Balance - 10000) * 0.01m;
                MakeDeposite(interest, DateTime.UtcNow, "Monthly interest", TransactionType.Interest);
            }
            else if (Status == AccountStatus.VIP && Balance > 10000)
            {
                decimal interest = (Balance - 10000) * 0.03m;
                MakeDeposite(interest, DateTime.UtcNow, "Monthly interest", TransactionType.Interest);
            }
        }

        // Переопределяем метод базового класса - класса object
        // ToString - возвращает строку с информацией об объекте

        /// <summary>
        /// Возвращает строковое представление счёта.
        /// </summary>
        /// <returns>Строка с информацией о владельце, номере и типе счёта.</returns>
        public override string ToString()
        {
            return $"Owner: {Owner}\taccount number: {Number} (тип счета {GetType()})";
        }

        public void PrintAuditLog()
        {
            _auditLog.PrintLog();
        }

    }

    
}

