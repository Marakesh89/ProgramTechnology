using NumGameSOLID.Settings;

namespace NumGameSOLID.GuessNumber.Settings;

public class GameSettings
{
    public int MaxNumber { get;  }
    public int MinNumber { get; }
    public int MaxAttempts { get;  }

    public GameSettings(IDifficulty difficulty)
    {
        if (difficulty == null)
        {
            throw new ArgumentNullException(nameof(difficulty));
        }

        if (difficulty.MinNumber >= difficulty.MaxNumber)
        {
            throw new ArgumentException("Minimum number must be less than maximum number.");
        }

        if (difficulty.MaxAttempts < 1)
        {
            throw new ArgumentException("Maximum attempts must be at least 1.");
        }

        MinNumber = difficulty.MinNumber;
        MaxNumber = difficulty.MaxNumber;
        MaxAttempts = difficulty.MaxAttempts;
    }
}
        


