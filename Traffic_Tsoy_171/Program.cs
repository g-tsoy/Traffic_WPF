using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TrafficLogic
{
    public class Program
    {
        const string FileName = "../../Traffic.txt";

        /// <summary>
        /// Методы чтения информации из файла
        /// </summary>

        static Route ReadRoute(StreamReader sr)
        {
            var line = sr.ReadLine();
            var parts = line.Split(';');
            if (parts.Length != 7)
                return null;

            var route = new Route
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                ABeginTime = int.Parse(parts[2]),
                AEndTime = int.Parse(parts[3]),
                BBeginTime = int.Parse(parts[4]),
                BEndTime = int.Parse(parts[5]),
                BusInterval = int.Parse(parts[6]),
                Stations = new List<Station>()
            };

            int stationNumber = int.Parse(sr.ReadLine());
            for (int i = 0; i < stationNumber; i++)
            {
                line = sr.ReadLine();
                parts = line.Split(';');
                if (parts.Length == 3)
                {
                    route.Stations.Add(new Station
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        StationInterval = int.Parse(parts[2])
                    });
                }
            }
            return route;
        }

        static List<Route> ReadData()
        {
            var routesFromFile = new List<Route>();
            using (var sr = new StreamReader(FileName))
            {
                while (!sr.EndOfStream)
                {
                    var routeFromFile = ReadRoute(sr);
                    routesFromFile.Add(routeFromFile);
                }
            }
            return routesFromFile;
        }

        /// <summary>
        /// Сортировка по времени прибытия автобуса
        /// </summary>

        static int SortTime(Time time1, Time time2)
        {
            return time1.Wait - time2.Wait;
        }

        static void Main(string[] args)
        {
            /// <summary>
            /// Считывание из файла
            /// </summary>

            List<Route> routes;
            try
            {
                routes = ReadData();
            }
            catch
            {
                Console.WriteLine("Error reading file data");
                return;
            }

            do
            {
                DateTime today = DateTime.Now;
                Console.WriteLine("\nCurrent time: {0:t}", today);//timeOfDay
                Console.Write("Enter station name (For example, A): ");
                Console.ForegroundColor = ConsoleColor.Green;
                string station = Console.ReadLine();

                if (station != string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();

                    List<Time> times = new List<Time>();
                    int indexStation = -1;

                    for (int i = 0; i < routes.Count; i++)
                    {
                        for (int j = 0; j < routes[i].Stations.Count; j++)
                        {
                            if (station == routes[i].Stations[j].Name)
                            {
                                int indexOfLastStation = routes[i].Stations.Count - 1;
                                indexStation = routes[i].Stations[j].Id;

                                /// <summary>
                                /// Если пользователь вводит станцию, которая есть в маршруте,
                                /// то по ее индексу программа находит наименьшее время
                                /// до каждой из конечных станций.
                                /// </summary>

                                int resFirst = routes[i].GetNearestBusTimeFirst(indexStation);
                                int resLast = routes[i].GetNearestBusTimeLast(indexStation);

                                times.Add(new Time() { RouteName = routes[i].Name, Wait = resFirst, Name = routes[i].Stations[0].Name });
                                times.Add(new Time() { RouteName = routes[i].Name, Wait = resLast, Name = routes[i].Stations[indexOfLastStation].Name });
                            }
                        }
                    }

                    /// <summary>
                    /// Если станция есть в одном из маршрутов,
                    /// то она была добавлена в список.
                    /// Происходит сортировка этого списка
                    /// по наименьшему времени ожидания и выводится на экран.
                    ///
                    /// Если снация не найдена, то выводится соответствущие сообщение на экран.
                    /// </summary>
                    
                    Console.WriteLine("Schedule:");
                    if (times.Count != 0)
                    {
                        times.Sort(SortTime);
                        foreach (var time in times)
                            if (station != time.Name)
                                Console.WriteLine("{0, -9}: The next bus in the destination {1,1} will be in {2,1} minutes", time.RouteName, time.Name, time.Wait);
                    }
                    else
                    {
                        Console.WriteLine("Station {0} is not found! Please, try again!", station);
                    }
                }
                else
                    break;

                Console.WriteLine("\nType Enter for exit");

            } while (true);
        }
    }
}
