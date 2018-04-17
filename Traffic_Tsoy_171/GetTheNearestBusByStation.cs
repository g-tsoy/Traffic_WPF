using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLogic
{
    public class GetTheNearestBusByStation
    {
        List<Time> times = new List<Time>();
        public List<Time> TimeToNextBus { get { return times; } }

        GetListOfStation InfoFromFile = new GetListOfStation();

        public GetTheNearestBusByStation(Station station)
        {
         //   List<Time> times = new List<Time>();

            List<Route> routes = InfoFromFile.RoutesFromFile;
            int indexStation = -1;

            for (int i = 0; i < routes.Count; i++)
            {
                for (int j = 0; j < routes[i].Stations.Count; j++)
                {
                    if (station.Name == routes[i].Stations[j].Name)
                    {
                        int indexOfLastStation = routes[i].Stations.Count - 1;
                        indexStation = routes[i].Stations[j].Id;

                        int resFirst = routes[i].GetNearestBusTimeFirst(indexStation);
                        int resLast = routes[i].GetNearestBusTimeLast(indexStation);

                        times.Add(new Time() { RouteName = routes[i].Name, Wait = resFirst, Name = routes[i].Stations[0].Name });
                        times.Add(new Time() { RouteName = routes[i].Name, Wait = resLast, Name = routes[i].Stations[indexOfLastStation].Name });
                    }
                }
            }
            
            times.Sort(SortTime);

            /*
            Console.WriteLine("Schedule:");
            if (times.Count != 0)
            {
                times.Sort(SortTimeToNextBuses);
                foreach (var time in times)
                    if (station.StationName != time.Name)
                        Console.WriteLine("{0, -9}: The next bus in the destination {1,1} will be in {2,1} minutes", time.RouteName, time.Name, time.Wait);
            }
            
            int SortTimeToNextBuses(Time time1, Time time2)
            {
                return time1.Wait - time2.Wait;
            }*/
        }

        static int SortTime(Time time1, Time time2)
        {
            return time1.Wait - time2.Wait;
        }
    }
}
