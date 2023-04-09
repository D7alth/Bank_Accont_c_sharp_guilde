using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class GiftCardAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;
        public override void PerformMonthEndTransaction()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
        
    }
}