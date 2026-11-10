namespace NumGameSOLID.GuessNumber.ConsoleUI;

public class ConsoleGameView : IGameView
{
    public string? ReadInput()
    {
        return Console.ReadLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
