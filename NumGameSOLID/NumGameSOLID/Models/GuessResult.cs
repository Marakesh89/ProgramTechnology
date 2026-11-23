namespace NumGameSOLID.Models;

public class GuessResult
{
    public string Message { get; }
    public bool IsGameOver { get; }
    public int AttemptsLeft { get; }

    public GuessResult(string message, bool isGameOver, int attemptsLeft)
    {
        Message = message;
        IsGameOver = isGameOver;
        AttemptsLeft = attemptsLeft;
    }


}
