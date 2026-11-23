namespace NumGameSOLID.GuessNumber.Settings;

public class GameSettings
{
    public int MaxNumber { get;  }
    public int MinNumber { get; }
    public int MaxAttempts { get;  }
    public Difficulty DifficultyLevel { get; set; }

    public GameSettings(int minNumber, int maxNumber,  int maxAttempts, Difficulty difficultyLevel)
    {
        if (minNumber >= maxNumber )
        {
            throw new ArgumentException("Minimum number must be less than maximum number.");
        }
        if (maxAttempts < 1)
        {
            throw new ArgumentException("Maximum attempts must be at least 1.");
        }

        MinNumber = minNumber;
        MaxNumber = maxNumber;        
        MaxAttempts = maxAttempts;
        DifficultyLevel = difficultyLevel;

        
    }
}
        


