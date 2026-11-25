# ProgramTechnology
flowchart TD
    Player("Игрок")

    subgraph Console["NumGameSOLID_Console — Консольное приложение"]
        Program("Program<br/>Ввод, вывод и управление игрой")
    end

    subgraph Core["NumGameSOLID — Библиотека классов"]
        User("User<br/>Профиль пользователя")
        UserService("UserService<br/>Поиск и регистрация пользователей")

        Game("Game<br/>Игровая логика и проверка попыток")
        Result("GuessResult<br/>Результат игрового хода")

        Settings("GameSettings<br/>Настройки игры")
        IDifficulty("IDifficulty<br/>Интерфейс сложности")
        Easy("EasyDifficulty<br/>Лёгкий уровень")
        Medium("MediumDifficulty<br/>Средний уровень")
        Hard("HardDifficulty<br/>Сложный уровень")

        INumber("INumberGenerator<br/>Интерфейс генерации числа")
        Random("RandomGenerator<br/>Генератор случайных чисел")

        Statistics("Statistics<br/>Статистика пользователя")

        IUserStorage("IUserStorage<br/>Интерфейс хранения пользователей")
        FileStorage("UserFileStorage<br/>Файловое хранилище")
    end

    UsersFile[("users.txt")]

    Player -->|вводит логин и числа| Program

    Program -->|авторизация и регистрация| UserService
    UserService -->|находит и создаёт| User
    User -->|содержит| Statistics

    Program -->|создаёт и запускает| Game
    Game -->|использует настройки| Settings
    Game -->|получает случайное число| INumber
    Random -->|реализует| INumber
    Game -->|возвращает результат хода| Result
    Game -->|обновляет статистику| Statistics

    Settings -->|получает параметры сложности| IDifficulty
    Easy -->|реализует| IDifficulty
    Medium -->|реализует| IDifficulty
    Hard -->|реализует| IDifficulty

    UserService -->|загружает и сохраняет пользователей| IUserStorage
    FileStorage -->|реализует| IUserStorage
    FileStorage -->|читает и записывает| UsersFile

    Program -->|выбирает сложность| Easy
    Program -->|выбирает сложность| Medium
    Program -->|выбирает сложность| Hard
