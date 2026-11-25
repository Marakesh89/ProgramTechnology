namespace NumGameSOLID.Settings;

public class HardDifficulty : IDifficulty
{
    public int MinNumber => 1;
    public int MaxNumber => 200;
    public int MaxAttempts => 5;
}
