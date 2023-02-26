namespace coIT.BewirbDich.Persistence.Outbox;

public sealed class OutboxMessage
{
    public string Content { get; set; } = string.Empty;
    public string? Error { get; set; }
    public Guid Id { get; set; }

    public DateTime OccurredOnUtc { get; set; }
    public DateTime? ProcessedOnUtc { get; set; }
    public string Type { get; set; } = string.Empty;
}