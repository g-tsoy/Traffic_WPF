using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLogic
{
    public class Route
    {
        /// <summary>
        /// Номер маршрута,
        /// название,
        /// время первого рейса из первой станции,
        /// время последнего рейса из первой станции,
        /// время первого рейса из последней станции,
        /// время последнего рейса из последней станции,
        /// интервал между автобусами,
        /// список станции
        /// </summary>

        public int Id { get; set; }
        public string Name { get; set; }
        public int ABeginTime { get; set; }
        public int AEndTime { get; set; }
        public int BBeginTime { get; set; }
        public int BEndTime { get; set; }
        public int BusInterval { get; set; }
        public List<Station> Stations { get; set; }

        /// <summary>
        /// Метод, который вначале по индексу станции
        /// считает интервал до конечной точки вообще.
        /// 
        /// Потом обращается к другому методу и возвращает 
        /// интервал ожидания автобуса с учетом настоящего времени.
        /// </summary>

        public int GetNearestBusTimeFirst(int indexStation)
        {
            int timeFromPointA = 0;
            int indexOfLastStation = Stations.Count - 1;

            for (int i = 0; i < indexStation; i++)
            {
                timeFromPointA += Stations[i].StationInterval;
            }
            return GetNearestTime(ABeginTime, AEndTime, timeFromPointA, indexOfLastStation);
        }

        /// <summary>
        /// Метод, который вначале по индексу станции
        /// считает интервал до начальной точки вообще.
        /// 
        /// Потом обращается к другому методу и возвращает 
        /// интервал ожидания автобуса с учетом настоящего времени.
        /// </summary>

        public int GetNearestBusTimeLast(int indexStation)
        {
            int timeFromPointB = 0;
            int indexOfLastStation = Stations.Count - 1;

            for (int i = indexOfLastStation; i > indexStation; i--)
            {
                timeFromPointB += Stations[i - 1].StationInterval;
            }
            return GetNearestTime(BBeginTime, BEndTime, timeFromPointB, 0);
        }

        /// <summary>
        /// Метод, который переводит текущее время в целочисленный тип.
        /// Затем учитывает интервалы между автобусами
        /// и считает непосредственно время прибытия автобуса на введенную станцию.
        /// Потом из этого значения времени вычитается значение текущего 
        /// и выводится время, которое надо ждать прибытия автобуса.
        /// </summary>

        public int GetNearestTime(int beginTime, int endTime, int timeFromPoint, int indexOfLastStation) //в процессе
        {
            DateTime currentTimeInDateTime = DateTime.Now;
            int currenTime = currentTimeInDateTime.Hour * 60 + currentTimeInDateTime.Minute;

            if (currenTime < 60)
                currenTime = 1440 + currenTime;

            int time = beginTime;
            while (time <= endTime)
            {
                int stationTime = time + timeFromPoint;

                if (stationTime >= currenTime)
                {
                    int timeNeedToWait = stationTime - currenTime;
                    return timeNeedToWait;
                }
                time += BusInterval;
            }
            return 0;
        }
    }
}