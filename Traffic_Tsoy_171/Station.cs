using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLogic
{
    public class Station
    {       
        /// <summary>
        /// Номер маршрута,
        /// название,
        /// интервал до следующей станции
        /// </summary>
            
        public int Id { get; set; }
        public string Name { get; set; }
        public int StationInterval { get; set; }
    }
}
