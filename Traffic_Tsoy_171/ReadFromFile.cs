using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TrafficLogic
{
    public class ReadFromFile
    {
        public static List<User> GetDataUser()
        {
            var textUsers = File.ReadAllText("../../../registredUsers.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(textUsers);
            return users;
        }

        public static List<Route> GetDataRoute()
        {
            var textTraffic = File.ReadAllText("../../../traffic.json");
            List<Route> routes = JsonConvert.DeserializeObject<List<Route>>(textTraffic);
            return routes;
        }
    }
}
