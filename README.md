# ProgramTechnology
```mermaid
flowchart TD
    Player("Игрок")

    subgraph ConsoleApp["NumGameSOLID_Console"]
        Program("Program<br/>Ввод, вывод и управление игрой")
    end

    subgraph Core["NumGameSOLID"]
        User("User<br/>Профиль пользователя")
        UserService("UserService<br/>Поиск и регистрация пользователей")

        Settings("GameSettings<br/>Настройки и диапазон чисел")
        Game("Game<br/>Проверка попыток и логика игры")
        GuessResult("GuessResult<br/>Результат игрового хода")

        IDifficulty("IDifficulty")
        Easy("EasyDifficulty")
        Medium("MediumDifficulty")
        Hard("HardDifficulty")

        INumber("INumberGenerator")
        RandomNumber("RandomGenerator")

        Statistics("Statistics<br/>Индивидуальная статистика пользователя")

        IUser("IUserStorage")
        FileStorage("UserFileStorage")
    end

    UsersFile[("users.txt")]

    Player -->|вводит логин и числа| Program

    Program -->|передаёт логин| UserService
    UserService -->|находит или создаёт| User
    User -->|содержит| Statistics

    Program -->|создаёт и запускает| Game
    Game -->|использует настройки| Settings
    Game -->|запрашивает случайное число| INumber
    RandomNumber -->|реализует| INumber
    Game -->|возвращает результат хода| GuessResult
    Game -->|обновляет статистику| Statistics

    Program -->|передаёт выбранную сложность| Settings
    Easy -->|реализует| IDifficulty
    Medium -->|реализует| IDifficulty
    Hard -->|реализует| IDifficulty
    Settings -->|получает параметры сложности| IDifficulty

    UserService -->|загружает и сохраняет пользователей| IUser
    FileStorage -->|реализует| IUser
    FileStorage -->|читает и записывает| UsersFile
    ```
