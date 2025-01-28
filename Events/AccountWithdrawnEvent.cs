namespace EventSource_Implementation_Behavior.Events
{
    public record AccountWithdrawnEvent(
        Guid accountId,
        decimal amount,
        string currency = "USD") : Event(accountId);
}
