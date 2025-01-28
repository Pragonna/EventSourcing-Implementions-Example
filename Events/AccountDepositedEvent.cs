namespace EventSource_Implementation_Behavior.Events
{
    public record AccountDepositedEvent(
        Guid accountId,
        decimal amount,
        string currency = "USD") : Event(accountId);
}
