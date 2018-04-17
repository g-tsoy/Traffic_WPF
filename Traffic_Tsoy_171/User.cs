using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLogic
{
    public class User
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Station> favouriteStation { get; set; }

    }
}
