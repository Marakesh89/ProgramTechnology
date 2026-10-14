namespace WeaponGame;

/// <summary>
/// Представляет меч — оружие ближнего боя.
/// Наследует основные характеристики от класса Weapon
/// и добавляет свойства, связанные с длиной клинка.
/// </summary>
public class Sword : Weapon
{
    /// <summary>
    /// Порог длины клинка, при превышении которого меч
    /// считается двуручным в рамках данной реализации.
    /// </summary>
    private readonly double _twoHandedBladeThreshold = 100;

    /// <summary>
    /// Получает или задаёт длину клинка меча.
    /// </summary>
    public double BladeLength { get; set; }

    /// <summary>
    /// Определяет, считается ли меч двуручным.
    /// Меч считается двуручным, если длина его клинка
    /// превышает установленный порог.
    /// </summary>
    public bool IsTwoHanded => BladeLength > _twoHandedBladeThreshold;

    /// <summary>
    /// Создаёт меч и инициализирует его основные характеристики.
    /// </summary>
    /// <param name="id">Идентификатор оружия.</param>
    /// <param name="name">Название меча.</param>
    /// <param name="damage">Урон одной атаки.</param>
    /// <param name="attackSpeed">Скорость атаки.</param>
    /// <param name="bladeLength">Длина клинка.</param>
    public Sword(
        int id,
        string name,
        int damage,
        double attackSpeed,
        double bladeLength)
        : base(id, name, damage)
    {
        AttackSpeed = attackSpeed;
        BladeLength = bladeLength;
        Type = WeaponType.Melee;
    }

    /// <summary>
    /// Выполняет атаку мечом.
    /// Выводит сообщение о нанесении удара.
    /// </summary>
    public override void Attack()
    {
        Console.WriteLine($"{Name} swings and strikes.");
    }

    /// <summary>
    /// Возвращает текстовое представление меча:
    /// его название, урон и тип оружия.
    /// </summary>
    /// <returns>Строка с основной информацией о мече.</returns>
    public override string ToString()
    {
        return $"[Sword] {Name}, {Damage} dmg, type: {Type}";
    }
}