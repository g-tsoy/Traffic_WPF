using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLogic
{
    public class Time
    {
        /// <summary>
        /// Название маршрута,
        /// время ожидания,
        /// конечная точка,
        /// </summary>

        public string RouteName { get; set; }
        public int Wait { get; set; }
        public string Name { get; set; }
    }
}
