namespace WeaponGame;

/// <summary>
/// Определяет тип оружия в игре.
/// Используется для классификации оружия по способу нанесения урона.
/// </summary>
public enum WeaponType
{
    /// <summary>
    /// Оружие ближнего боя, например меч.
    /// </summary>
    Melee,

    /// <summary>
    /// Оружие дальнего боя, например лук.
    /// </summary>
    Ranged,

    /// <summary>
    /// Магическое оружие, например посох.
    /// </summary>
    Magic
}