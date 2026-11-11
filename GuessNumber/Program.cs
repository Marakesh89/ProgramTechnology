using NumGameSOLID.GuessNumber.ConsoleUI;
using NumGameSOLID.GuessNumber.RandomNumberGenerator;
using NumGameSOLID.GuessNumber.Services;
using NumGameSOLID.GuessNumber.GameResult;
using NumGameSOLID.GuessNumber.Settings;
namespace NumGameSOLID.GuessNumber;

internal class Program
{
    static void Main(string[] args)
    {
        var generateNum = new RandomGenerator();
        var statistics = new Statistics();
        var consoleUi = new ConsoleGameView();
        var difficultySettings = new DifficultySettings();
        var statisticsStorage = new StatisticsStorage();
        consoleUi.ShowMessage("Выберите уровень сложности:" +
            "\n 1. Легкий (числа от 1 до 50, 10 попыток)" +
            "\n 2. Средний (1-100, 7 попыток)" +
            "\n 3. Сложный (1-200, 5 попыток)");
        string? input = consoleUi.ReadInput();
        GameSettings settings;
        switch (input)
        {
            case "1":
                var easySettings = difficultySettings.GetSettings(Difficulty.Easy);
                settings = easySettings;
                break;
            case "2":
                var mediumSettings = difficultySettings.GetSettings(Difficulty.Medium);
                settings = mediumSettings;
                break;
            case "3":
                var hardSettings = difficultySettings.GetSettings(Difficulty.Hard);
                settings = hardSettings;
                break;
            default:
                consoleUi.ShowMessage("Неверный выбор. Пожалуйста, выберите 1, 2 или 3.");
                return;
        }

        var game = new Game(generateNum, statistics, consoleUi, settings);
        game.Start();
        var saveResult = statisticsStorage.Save(statistics);
        if (!saveResult)
        {
            consoleUi.ShowMessage("Ошибка при сохранении статистики.");
        }
        else
        {
            consoleUi.ShowMessage("Статистика успешно сохранена.");
        }
    }
}
