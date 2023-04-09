using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit){}
        public override void PerformMonthEndTransaction()
        {
            if(Balance < 0)
            {
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }
        protected override Transaction? checkedWithDrawalLimit(bool isOverdraw) =>
            isOverdraw ? new Transaction(-20, DateTime.Now, "Apply overdraft fee") : default;
    }
}