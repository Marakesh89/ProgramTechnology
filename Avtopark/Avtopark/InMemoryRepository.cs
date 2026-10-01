using System.Collections.Generic;

namespace AutoPark
{
    /// <summary>
    /// Репозиторий с тестовыми данными в памяти.
    /// </summary>
    public class InMemoryRepository
    {
        private List<Route> _routes;
        private List<Car> _cars;
        private List<Driver> _drivers;

        public InMemoryRepository()
        {
            _routes = new List<Route>
            {
                new Route(1, "Городской",   25),
                new Route(2, "Загородный",  75),
                new Route(3, "Пригородный", 40),
                new Route(4, "Экспресс",    120),
                new Route(5, "Ночной",      60)
            };

            _cars = new List<Car>
            {
                new Car(1, "Toyota Camry",    1, 2021, "А123БВ"),
                new Car(2, "Kia Rio",         2, 2019, "Б456ВГ"),
                new Car(3, "Ford Focus",      1, 2022, "В789ГД"),
                new Car(4, "Hyundai Solaris", 3, 2018, "Г012ДЕ"),
                new Car(5, "Toyota Camry",    4, 2023, "Д345ЕЖ")
            };

            _drivers = new List<Driver>
            {
                new Driver(1, "Иванов И.И.",  1, 10, "A123"),
                new Driver(2, "Петров П.П.",  2, 3,  "B456"),
                new Driver(3, "Сидоров С.С.", 3, 8,  "C789"),
                new Driver(4, "Иванов И.И.",  5, 10, "A123"),
                new Driver(5, "Орлов А.А.",   4, 6,  "D012")
            };
        }


        public List<Route> GetRoutes() { return _routes; }
        public List<Car> GetCars() { return _cars; }
        public List<Driver> GetDrivers() { return _drivers; }
    }
}