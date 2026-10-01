using System;

namespace AutoPark
{
    /// <summary>
    /// Машина автопарка.
    /// </summary>
    public class Car
    {
        public int Id { get; private set; }
        public string Model { get; private set; }
        public int RouteId { get; private set; }   
        public int Year { get; private set; }
        public string Number { get; private set; }

        /// <summary>
        /// Создаёт машину с проверкой входных данных.
        /// </summary>
        public Car(int id, string model, int routeId, int year, string number)
        {
            if (id <= 0)
                throw new ArgumentException("Id должен быть положительным", nameof(id));
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model не может быть пустой", nameof(model));
            if (routeId <= 0)
                throw new ArgumentException("RouteId должен быть положительным", nameof(routeId));
            if (year < 1900 || year > 2100)
                throw new ArgumentException("Year должен быть в диапазоне 1900–2100", nameof(year));
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Number не может быть пустым", nameof(number));

            Id = id;
            Model = model;
            RouteId = routeId;
            Year = year;
            Number = number;
        }

        public bool IsNew
        {
            get { return Year >= 2020; }
        }

        public string GetInfo()
        {
            return $"{Model} ({Year}, {Number})";
        }
    }
}