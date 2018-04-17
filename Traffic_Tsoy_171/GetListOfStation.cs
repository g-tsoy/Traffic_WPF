using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TrafficLogic
{
    public class GetListOfStation //ReadData<Route>
    {
        List<Station> stationsFromRoutes = new List<Station>();
        public List<Station> StationsFromRoutes { get { return stationsFromRoutes; } }

        List<Route> routes;
        public List<Route> RoutesFromFile { get { return routes; } }

        //ReadData<Route>.ReadFromFile(file) = "../../../traffic.json";

        public GetListOfStation()
        {
            routes = ReadFromFile.GetDataRoute();
            stationsFromRoutes = GenerateData();
        }

        public List<Station> GenerateData()
        {
            for (int i = 0; i < routes.Count; i++)
            {
                for (int j = 0; j < routes[i].Stations.Count; j++)
                {
                    Station newStation = routes[i].Stations[j];

                    if (Contain(newStation, stationsFromRoutes) == true)
                    {
                        stationsFromRoutes.Add(new Station() { Name = routes[i].Stations[j].Name });
                    }
                }
            }
            return stationsFromRoutes;
        }

        //убрать в другое место
        public bool Contain(Station newStation, List<Station> list)
        {
            foreach (Station station in list)
            {
                if (newStation.Name.Contains(station.Name))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
