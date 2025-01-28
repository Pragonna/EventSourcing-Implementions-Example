namespace EventSource_Implementation_Behavior.Events
{
    public record MoneyTransferEvent(
        Guid accountId,
        Guid toAccountId,
        decimal amount,
        string currency = "USD") : Event(accountId);
}
