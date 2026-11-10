namespace NumGameSOLID.GuessNumber.ConsoleUI;

public interface IGameView
{
    public void ShowMessage(string message);
    public string? ReadInput();
}
