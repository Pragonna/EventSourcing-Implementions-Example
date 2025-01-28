
# Event-Sourced Bank Account System

This repository contains an implementation of an **Event-Sourced Bank Account System** written in C#. The system models a basic bank account with key features such as opening accounts, deposits, withdrawals, transfers, and account closures. Each operation is event-driven, allowing for a robust and auditable system.

## Features
- **Open a Bank Account**: Create a new account with an initial deposit.
- **Deposit Money**: Add funds to an existing account.
- **Withdraw Money**: Subtract funds from an account (if sufficient balance exists).
- **Transfer Money**: Transfer funds between accounts.
- **Event Sourcing**: All actions are recorded as events.
- **Account Closure**: Close accounts after ensuring a zero balance.

## Key Concepts
### Event Sourcing
Event sourcing is a pattern where state changes to an application are captured as a sequence of events. These events can then be used to:
- Rebuild the current state of the system.
- Debug and audit operations.

### Events Used in the System
1. `AccountOpenedEvent`: Triggered when a new account is created.
2. `AccountDepositedEvent`: Triggered when a deposit is made.
3. `AccountWithdrawnEvent`: Triggered when a withdrawal is made.
4. `MoneyTransferEvent`: Triggered when money is transferred between accounts.
5. `AccountClosedEvent`: Triggered when an account is closed.

## Project Structure
The key class in this project is the `BankAccount` class, which represents a bank account and implements event sourcing to handle various operations.

### BankAccount Class
#### Properties
- **Id**: Unique identifier for the account.
- **Holder**: Name of the account holder.
- **Balance**: Current balance of the account.
- **Events**: List of all events applied to the account.
- **IsActive**: Indicates if the account is active.

#### Methods
1. `Open`: Opens a new bank account with an initial deposit.
2. `Deposit`: Adds funds to the account.
3. `Withdraw`: Withdraws funds from the account (if sufficient balance exists).
4. `Transfer`: Transfers funds to another account.
5. `Apply`: Applies an event to update the account's state.
6. `CloseAccount`: Closes the account after ensuring the balance is zero.
7. `EnsureAccountBalanceIsZero`: Validates that the account balance is zero before closure.

## How It Works
### Opening an Account
```csharp
var account = BankAccount.Open("John Doe", 1000);
```
When an account is opened, an `AccountOpenedEvent` is created and applied. This updates the account's state and sets it as active.

### Depositing Money
```csharp
account.Deposit(500);
```
When a deposit is made, an `AccountDepositedEvent` is created and applied. The account's balance is updated accordingly.

### Withdrawing Money
```csharp
account.Withdraw(300);
```
When a withdrawal is made, an `AccountWithdrawnEvent` is created and applied. The balance is decremented by the withdrawal amount.

### Transferring Money
```csharp
account.Transfer(200, destinationAccountId);
```
When funds are transferred, a `MoneyTransferEvent` is created and applied. The sender's balance is reduced.

### Closing an Account
```csharp
account.CloseAccount(account);
```
Before closing the account, the system ensures that the balance is zero. After successful validation, the account is marked as inactive, and all events are cleared.

## Prerequisites
- .NET SDK (>= 6.0)
- A basic understanding of C# and event sourcing patterns.

## Getting Started
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/EventSource-BankAccount.git
   ```
2. Navigate to the project directory:
   ```bash
   cd EventSource-BankAccount
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the tests:
   ```bash
   dotnet test
   ```

## Example Usage
```csharp
using EventSource_Implementation_Behavior;

class Program
{
    static void Main(string[] args)
    {
        var account = BankAccount.Open("Alice", 1000);
        account.Deposit(500);
        account.Withdraw(200);

        Console.WriteLine($"Account Holder: {account.Holder}");
        Console.WriteLine($"Current Balance: {account.Balance}");

        account.CloseAccount(account);
        Console.WriteLine("Account closed successfully.");
    }
}
```

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature/bugfix.
3. Commit your changes.
4. Open a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For questions or feedback, feel free to reach out at your-email@example.com.

---

Happy coding!
