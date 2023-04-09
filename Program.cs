using classes;

var account = new BankAccount("alberth", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.GetAccountHistory());

var giftCard = new GiftCardAccount("Gift Card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransaction();

giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add some money");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransaction();
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("Line of credit", 0, 900);

lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeDeposit(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
Console.WriteLine(lineOfCredit.GetAccountHistory());


// Test that the initial balance must be positive;

/*BankAccount invalidAccount;

try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balace");
    Console.WriteLine(e.ToString());
    return;
}*/

// Test for a negative balace;

/*try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
}
catch(InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}*/