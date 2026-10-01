using System;

namespace AutoPark
{
    /// <summary>
    /// Маршрут, который обслуживает машина.
    /// </summary>
    public class Route
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Distance { get; private set; }

        /// <summary>
        /// Создаёт маршрут с проверкой входных данных.
        /// </summary>
        public Route(int id, string name, int distance)
        {
            if (id <= 0)
                throw new ArgumentException("Id должен быть положительным", nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name не может быть пустым", nameof(name));
            if (distance < 0)
                throw new ArgumentException("Distance не может быть отрицательным", nameof(distance));

            Id = id;
            Name = name;
            Distance = distance;
        }

        public bool IsLong
        {
            get { return Distance > 50; }
        }

        public string GetInfo()
        {
            return $"{Name} ({Distance} км)";
        }
    }
}