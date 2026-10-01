using System;
using System.Collections.Generic;
using System.IO;

namespace AutoPark
{
    /// <summary>
    /// Репозиторий, читающий данные из CSV-файлов.
    /// </summary>
    public class CsvRepository
    {
        private string _basePath;

        public CsvRepository(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Путь к папке с CSV не может быть пустым", nameof(basePath));
            _basePath = basePath;
        }

        public List<Route> GetRoutes()
        {
            List<Route> result = new List<Route>();
            string path = Path.Combine(_basePath, "routes.csv");
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;

                int id = int.Parse(parts[0]);
                string name = parts[1];
                int distance = int.Parse(parts[2]);

                Route r = new Route(id, name, distance);   
                result.Add(r);
            }
            return result;
        }

        public List<Car> GetCars()
        {
            List<Car> result = new List<Car>();
            string path = Path.Combine(_basePath, "cars.csv");
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 5) continue;

                int id = int.Parse(parts[0]);
                string model = parts[1];
                int routeId = int.Parse(parts[2]);
                int year = int.Parse(parts[3]);
                string number = parts[4];

                Car c = new Car(id, model, routeId, year, number);
                result.Add(c);
            }
            return result;
        }

        public List<Driver> GetDrivers()
        {
            List<Driver> result = new List<Driver>();
            string path = Path.Combine(_basePath, "drivers.csv");
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 5) continue;

                int id = int.Parse(parts[0]);
                string fullName = parts[1];
                int carId = int.Parse(parts[2]);
                int experience = int.Parse(parts[3]);
                string license = parts[4];

                Driver d = new Driver(id, fullName, carId, experience, license);
                result.Add(d);
            }
            return result;
        }
    }
}