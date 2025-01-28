namespace EventSource_Implementation_Behavior.Events
{
    public record AccountOpenedEvent(
        Guid accountId,
        string accountHolder,
        decimal initialDeposit,
        string currency = "USD") : Event(accountId);
}
