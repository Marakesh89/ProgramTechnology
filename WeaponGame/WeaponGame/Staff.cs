namespace WeaponGame;

/// <summary>
/// Представляет магический посох.
/// Наследует основные характеристики от класса Weapon
/// и добавляет свойства, связанные с расходом маны.
/// </summary>
public class Staff : Weapon
{
    /// <summary>
    /// Минимальный урон, необходимый для того,
    /// чтобы посох считался мощным в рамках данной реализации.
    /// </summary>
    private readonly int _powerfulDamageThreshold = 50;

    /// <summary>
    /// Получает или задаёт количество маны,
    /// расходуемое при использовании посоха.
    /// </summary>
    public int ManaCost { get; set; }

    /// <summary>
    /// Определяет, считается ли посох мощным.
    /// Для этого урон должен быть не меньше установленного порога,
    /// а расход маны — не меньше 20 единиц.
    /// </summary>
    public bool IsPowerful =>
        Damage >= _powerfulDamageThreshold && ManaCost >= 20;

    /// <summary>
    /// Создаёт магический посох и инициализирует его характеристики.
    /// </summary>
    /// <param name="id">Идентификатор оружия.</param>
    /// <param name="name">Название посоха.</param>
    /// <param name="damage">Урон одной атаки.</param>
    /// <param name="attackSpeed">Скорость атаки.</param>
    /// <param name="manaCost">Количество маны, расходуемое при использовании.</param>
    public Staff(
        int id,
        string name,
        int damage,
        double attackSpeed,
        int manaCost)
        : base(id, name, damage)
    {
        AttackSpeed = attackSpeed;
        ManaCost = manaCost;
        Type = WeaponType.Magic;
    }

    /// <summary>
    /// Выполняет магическую атаку с помощью посоха.
    /// Выводит сообщение о применении магического заклинания.
    /// </summary>
    public override void Attack()
    {
        Console.WriteLine($"{Name} casts a magical spell.");
    }

    /// <summary>
    /// Возвращает текстовое представление посоха:
    /// его название, урон и тип оружия.
    /// </summary>
    /// <returns>Строка с основной информацией о посохе.</returns>
    public override string ToString()
    {
        return $"[Staff] {Name}, {Damage} dmg, type: {Type}";
    }
}