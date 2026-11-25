namespace NumGameSOLID.Settings;

public class MediumDifficulty : IDifficulty
{
    public int MinNumber => 1;
    public int MaxNumber => 100;
    public int MaxAttempts => 7;

}
