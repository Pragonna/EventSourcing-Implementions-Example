
using EventSource_Implementation_Behavior;

var bankAccount = BankAccount.Open("Pragonna", 1000);

bankAccount.Transfer(500, Guid.NewGuid());
bankAccount.Deposit(400);
bankAccount.Withdraw(200);

Console.WriteLine($"Bank Account Balance: {bankAccount.Balance}");

Console.WriteLine("_____________________________________________________");

foreach (var @event in bankAccount.Events)
{
    Console.WriteLine($"{@event.GetType().Name} is created at {@event.Timestamp}");
}

bankAccount.CloseAccount(bankAccount); // this will throw an exception

Console.WriteLine("Bank Account is closed"); 


