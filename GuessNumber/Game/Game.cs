using NumGameSOLID.GuessNumber.Interfaces;
using NumGameSOLID.GuessNumber.Services;

namespace NumGameSOLID.GuessNumber.Game;

internal class Game
{
    private readonly INumberGenerator _numberGenerator;
    private readonly Statistics _staticstics;

    public int _secretNum;
    public int _attemps;

    public Game(INumberGenerator numberGenerator, Statistics staticstics)
    {
        _numberGenerator = numberGenerator;
        _staticstics = staticstics;
    }

    public void Start()
    {
        _secretNum = _numberGenerator.Generate(1, 101);
        _attemps = 0;

        Console.WriteLine("Угадай число от 1 до 100");

        while (true)
        {
            Console.WriteLine("Введите число: ");

            if (!int.TryParse(Console.ReadLine(), out int userNumber))
            {
                Console.WriteLine("Введите корректное число!");
                continue;
            }

            if (userNumber < 1 || userNumber > 100)
            {
                Console.WriteLine("Неверное число\n Число должно быть от 1 до 100");
                continue;
            }

            if (userNumber > _secretNum) { Console.WriteLine("Загадонное число меньше"); }
            else if (userNumber < _secretNum) { Console.WriteLine("Загадонное число больше"); }
            else
            {
                Console.WriteLine($"Поздравляю, ты угадал число за {_attemps} попыток");
                _staticstics.AddGame(_attemps);
                break;
            }

        }
    }
}
