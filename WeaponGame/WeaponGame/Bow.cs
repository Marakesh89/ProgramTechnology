namespace WeaponGame;

/// <summary>
/// Представляет лук — оружие дальнего боя.
/// Наследует общие характеристики от класса Weapon
/// и реализует интерфейс IReloadable для поддержки перезарядки.
/// </summary>
public class Bow : Weapon, IReloadable
{
    /// <summary>
    /// Количество стрел, добавляемых при перезарядке лука.
    /// </summary>
    private readonly int _reloadArrowCount = 10;

    /// <summary>
    /// Получает или задаёт текущее количество стрел.
    /// </summary>
    public int ArrowCount { get; set; }

    /// <summary>
    /// Определяет, закончились ли стрелы.
    /// Возвращает true, если количество стрел равно нулю.
    /// </summary>
    public bool IsEmpty => ArrowCount == 0;

    /// <summary>
    /// Создаёт лук и инициализирует его основные характеристики.
    /// </summary>
    /// <param name="id">Идентификатор оружия.</param>
    /// <param name="name">Название лука.</param>
    /// <param name="damage">Урон одной атаки.</param>
    /// <param name="attackSpeed">Скорость атаки.</param>
    /// <param name="arrowCount">Начальное количество стрел.</param>
    public Bow(
        int id,
        string name,
        int damage,
        double attackSpeed,
        int arrowCount)
        : base(id, name, damage)
    {
        AttackSpeed = attackSpeed;
        ArrowCount = arrowCount;
        Type = WeaponType.Ranged;
    }

    /// <summary>
    /// Выполняет атаку из лука.
    /// Если стрел нет, выводит сообщение об отсутствии боеприпасов
    /// и завершает выполнение метода.
    /// Если стрелы есть, выводит сообщение о выстреле
    /// и уменьшает количество стрел на одну.
    /// </summary>
    public override void Attack()
    {
        if (IsEmpty)
        {
            Console.WriteLine($"{Name} has no arrows.");
            return;
        }

        Console.WriteLine($"{Name} fires an arrow.");
        ArrowCount--;
    }

    /// <summary>
    /// Восстанавливает запас стрел до установленного количества.
    /// </summary>
    public void Reload()
    {
        ArrowCount = _reloadArrowCount;
        Console.WriteLine($"{Name} reloads arrows.");
    }

    /// <summary>
    /// Возвращает текстовое представление лука:
    /// его название, урон, тип оружия и количество стрел.
    /// </summary>
    /// <returns>Строка с основной информацией о луке.</returns>
    public override string ToString()
    {
        return $"[Bow] {Name}, {Damage} dmg, type: {Type}, arrows: {ArrowCount}";
    }
}