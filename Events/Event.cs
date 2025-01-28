namespace EventSource_Implementation_Behavior.Events
{

    public abstract record Event(Guid Id)
    {
        public DateTime Timestamp { get; init; } = DateTime.Now;

    }
}
