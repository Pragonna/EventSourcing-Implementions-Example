namespace EventSource_Implementation_Behavior.Events
{
    public record AccountClosedEvent(
        Guid accountId,
        decimal amount,
        string currency = "USD") : Event(accountId);
}
