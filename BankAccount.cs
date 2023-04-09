using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 123456790;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        { 
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                
                return balance;
            }
        }

        private readonly decimal _minimumBalance;

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0){}

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance){
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            _minimumBalance = minimumBalance;
            if(initialBalance > 0) MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");        
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdraw must be positive");
            Transaction? overdraftTransaction = checkedWithDrawalLimit(Balance - amount < _minimumBalance);
            Transaction? withdrawal = new(-amount, date, note);
            allTransactions.Add(withdrawal);
            if(overdraftTransaction != null) allTransactions.Add(overdraftTransaction);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();
            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalace\tNote");
            foreach(var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            return report.ToString();
        }
        public virtual void PerformMonthEndTransaction(){}
        protected virtual Transaction? checkedWithDrawalLimit(bool isOverdraw) 
        {
            if(isOverdraw) throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            else return default;
        }
    }
}