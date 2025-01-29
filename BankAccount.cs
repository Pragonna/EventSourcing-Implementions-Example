using EventSource_Implementation_Behavior.Events;

namespace EventSource_Implementation_Behavior
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public string Holder { get; set; }
        public decimal Balance { get; set; }
        public List<Event> Events { get; set; } = [];
        public bool IsActive { get; set; }

        private BankAccount()
        {
            Id = Guid.NewGuid();
        }

        public static BankAccount Open(string holder, decimal initialDeposit, string currency = "USD")
        {
            if (initialDeposit <= 0)
            {
                throw new ArgumentException("Initial deposit must be greater than 0");
            }

            if (string.IsNullOrWhiteSpace(holder))
            {
                throw new ArgumentException("Holder name is required");
            }


            var account = new BankAccount();
            account.Apply(new AccountOpenedEvent(account.Id, holder, initialDeposit, currency));
            return account;
        }


        public void Deposit( decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than 0");
            }
            Apply(new AccountDepositedEvent(Id, amount));
            
        }


        public void Withdraw( decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than 0");
            }
            if (amount > Balance)
            {
                throw new ArgumentException("Insufficient funds");
            }
            Apply(new AccountWithdrawnEvent(Id, amount));
        }
        public void Transfer( decimal amount, Guid destinationAccountId)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Transfer amount must be greater than 0");
            }
            if (amount > Balance)
            {
                throw new ArgumentException("Insufficient funds");
            }
            Apply(new MoneyTransferEvent(Id, destinationAccountId, amount));

        }
      
        private void Apply(Event @event)
        {
            switch (@event)
            {
                case AccountOpenedEvent accountOpened:
                    Id = accountOpened.accountId;
                    Holder = accountOpened.accountHolder;
                    Balance = accountOpened.initialDeposit;
                    IsActive = true;
                    break;
                case AccountDepositedEvent accountDeposited:
                    Balance += accountDeposited.amount;
                    break;
                case AccountWithdrawnEvent accountWithdrawn:
                    Balance -= accountWithdrawn.amount;
                    break;
                case MoneyTransferEvent moneyTransfer:
                    Balance -= moneyTransfer.amount;
                    break;
                case AccountClosedEvent accountClosed:
                    CloseAccount(this);
                    break;

                default:
                    break;
            }
            Events.Add(@event);
        }

        public bool CloseAccount(BankAccount account)
        {
            EnsureAccountBalanceIsZero(account);
            IsActive = false;

            // all events are applied, so we can now close the account
            // log events

            Events.Clear();

            return true;
        }

        public void EnsureAccountBalanceIsZero(BankAccount bankAccount)
        {
            if (bankAccount.Balance != 0)
            {
                throw new ArgumentException("Account balance must be zero before closing");
            }
        }
    }
}
