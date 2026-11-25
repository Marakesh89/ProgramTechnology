namespace NumGameSOLID.Settings;

public class EasyDifficulty : IDifficulty
{
    public int MinNumber => 1;
    public int MaxNumber => 50;
    public int MaxAttempts => 10;

}
