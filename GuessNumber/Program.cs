using NumGameSOLID.GuessNumber.ConsoleUI;
using NumGameSOLID.GuessNumber.RandomNumberGenerator;
using NumGameSOLID.GuessNumber.Services;
using NumGameSOLID.GuessNumber.GameResult;
namespace NumGameSOLID.GuessNumber;

internal class Program
{
    static void Main(string[] args)
    {
        var generateNum = new RandomGenerator();
        var statistics = new Statistics();
        var consoleUi = new ConsoleGameView();
        var game = new Game(generateNum, statistics, consoleUi);
        game.Start();
    }
}
