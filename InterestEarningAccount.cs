using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class InterestEarningAccount : BankAccount
    {
        // Note: Ao herdar da classe base (bankacount) precisamos iniciar os valores que ela recebe de parametro, uma das forma e passar os valores do construtor da classe filho para a classe base diretamente dentro do construtor
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance){}
        public override void PerformMonthEndTransaction()
        {
            if(Balance > 500m)
            {
                decimal interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "Aply monthly interest");
            }
        }

    }
}