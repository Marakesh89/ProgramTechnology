namespace NumGameSOLID.Settings;

public interface IDifficulty
{
    int MinNumber { get; }
    int MaxNumber { get; }
    int MaxAttempts { get; }
}
