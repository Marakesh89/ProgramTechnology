using System;
using System.Collections.Generic;

namespace AutoPark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 — InMemoryRepository");
            Console.WriteLine("2 — CsvRepository (папка data)");
            Console.Write("Ваш выбор: ");
            string? input = Console.ReadLine();
            int choice;

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Неверный выбор");
                return;
            }

            List<Route> routes;
            List<Car> cars;
            List<Driver> drivers;

            switch (choice)
            {
                case 1:
                    try
                    {
                        InMemoryRepository mem = new InMemoryRepository();
                        routes = mem.GetRoutes();
                        cars = mem.GetCars();
                        drivers = mem.GetDrivers();
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Некорректные данные (InMemory): {e.Message}");
                        return;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка (InMemory): {e.Message}");
                        return;
                    }
                    break;

                case 2:
                    try
                    {
                        CsvRepository csv = new CsvRepository("data");
                        routes = csv.GetRoutes();
                        cars = csv.GetCars();
                        drivers = csv.GetDrivers();
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine($"Файл не найден: {e.FileName}");
                        return;
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine($"Папка не найдена: {e.Message}");
                        return;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Ошибка формата CSV: {e.Message}");
                        return;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Некорректные данные (CSV): {e.Message}");
                        return;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Непредвиденная ошибка: {e.Message}");
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }

            // 1. FindDriver
            string testNumber = "А123БВ";
            Driver? foundDriver = FindDriver(cars, drivers, testNumber);
            Console.WriteLine($"1. FindDriver(\"{testNumber}\"): " +
                (foundDriver != null ? foundDriver.GetInfo() : "null"));

            // 2. FindRoute
            Car? carForSearch = null;
            foreach (Car c in cars) { if (c.Number == "А123БВ") { carForSearch = c; break; } }
            Route?  foundRoute = FindRoute(routes, carForSearch);
            Console.WriteLine($"2. FindRoute(car \"Toyota Camry\"): " +
                (foundRoute != null ? foundRoute.GetInfo() : "null"));

            // 3. GetTotalDistance
            int total = GetTotalDistance(routes);
            Console.WriteLine($"3. GetTotalDistance: {total} км");

            // 4. GetDriversWithMultipleCars
            List<string> multi = GetDriversWithMultipleCars(drivers);
            Console.Write("4. GetDriversWithMultipleCars: ");
            if (multi.Count == 0)
            {
                Console.WriteLine("нет");
            }
            else
            {
                for (int i = 0; i < multi.Count; i++)
                {
                    Console.Write(multi[i]);
                    if (i < multi.Count - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }

            
            Console.WriteLine("5. PrintAllCars:");
            PrintAllCars(cars, routes, drivers);

            Console.WriteLine();
            Driver? notFound = FindDriver(cars, drivers, "Х000ХХ");
            Console.WriteLine("Не найдено: FindDriver(\"Х000ХХ\") → " +
                (notFound != null ? notFound.GetInfo() : "null"));
        }

        /// <summary>
        /// Находит водителя по номеру машины. Если не найдено — null.
        /// </summary>
        static Driver? FindDriver(List<Car>? cars, List<Driver>? drivers, string? carNumber)
        {
            if (cars == null || drivers == null || carNumber == null)
                return null;

            Car? foundCar = null;
            foreach (Car car in cars)
            {
                if (car.Number == carNumber)
                {
                    foundCar = car;
                    break;
                }
            }
            if (foundCar == null) return null;

            foreach (Driver d in drivers)
            {
                if (d.CarId == foundCar.Id)
                    return d;
            }
            return null;
        }

        /// <summary>
        /// Находит маршрут для переданной машины. Если не найдено — null.
        /// </summary>
        static Route? FindRoute(List<Route>? routes, Car? car)
        {

            if (routes == null || car == null)
                return null;

            if (car == null) return null;

            foreach (Route r in routes)
            {
                if (r.Id == car.RouteId)
                {
                    return r;
                }
            }
            return null;
        }

        /// <summary>
        /// Суммарная протяжённость всех маршрутов. Пустой список — 0.
        /// </summary>
        static int GetTotalDistance(List<Route>? routes)
        {
            if (routes == null)
                return 0;

            int total = 0;
            foreach (Route r in routes)
            {
                total += r.Distance;
            }
            return total;
        }

        /// <summary>
        /// Возвращает список ФИО водителей, у которых более одной машины.
        /// </summary>
        static List<string> GetDriversWithMultipleCars(List<Driver> drivers)
        {

            if (drivers == null)
                return new List<string>();

            List<string> result = new List<string>();
            List<string> checkedNames = new List<string>();  

            foreach (Driver d in drivers)
            {
                bool alreadyChecked = false;
                foreach (string n in checkedNames)
                {
                    if (n == d.FullName) { alreadyChecked = true; break; }
                }
                if (alreadyChecked) continue;

                checkedNames.Add(d.FullName);

                List<int> carIds = new List<int>();
                foreach (Driver other in drivers)
                {
                    if (other.FullName == d.FullName)
                    {
                        bool seen = false;
                        foreach (int id in carIds)
                        {
                            if (id == other.CarId) { seen = true; break; }
                        }
                        if (!seen) carIds.Add(other.CarId);
                    }
                }

                if (carIds.Count > 1)
                {
                    result.Add(d.FullName);
                }
            }

            return result;
        }

        /// <summary>
        /// Печатает все машины с водителем и маршрутом.
        /// </summary>
        static void PrintAllCars(List<Car>? cars, List<Route>? routes, List<Driver>? drivers)
        {

            if (cars == null || routes == null || drivers == null)
            {
                Console.WriteLine("Нет данных для вывода");
                return;
            }

            foreach (Car car in cars)
            {
                Driver? driver = null;
                foreach (Driver d in drivers)
                {
                    if (d.CarId == car.Id) { driver = d; break; }
                }

                Route? route = FindRoute(routes, car);

                string driverText = driver != null ? driver.GetInfo() : "—";
                string routeText = route != null ? $"{route.Name}" : "—";
                string distanceText = route != null ? $"{route.Distance} км" : "";

                System.Console.WriteLine(
                    $"\"{car.GetInfo()}\" — водитель {driverText}, маршрут \"{routeText}\" ({distanceText})"
                );
            }
        }
    }
}