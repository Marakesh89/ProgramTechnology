using System;

namespace AutoPark
{
    /// <summary>
    /// Водитель, закреплённый за машиной.
    /// </summary>
    public class Driver
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public int CarId { get; private set; }     
        public int Experience { get; private set; }
        public string License { get; private set; }

        /// <summary>
        /// Создаёт водителя с проверкой входных данных .
        /// </summary>
        public Driver(int id, string fullName, int carId, int experience, string license)
        {
            if (id <= 0)
                throw new ArgumentException("Id должен быть положительным", nameof(id));
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("FullName не может быть пустым", nameof(fullName));
            if (carId <= 0)
                throw new ArgumentException("CarId должен быть положительным", nameof(carId));
            if (experience < 0)
                throw new ArgumentException("Experience не может быть отрицательным", nameof(experience));
            if (string.IsNullOrWhiteSpace(license))
                throw new ArgumentException("License не может быть пустым", nameof(license));

            Id = id;
            FullName = fullName;
            CarId = carId;
            Experience = experience;
            License = license;
        }

        public bool IsExperienced
        {
            get { return Experience > 5; }
        }

        public string GetInfo()
        {
            return $"{FullName} ({Experience} лет стажа)";
        }
    }
}