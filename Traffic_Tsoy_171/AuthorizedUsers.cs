using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLogic
{
    public class AuthorizedUsers //: IEquatable<User>//IRepository<User> 
    {
        List<User> users;
        public List<User> Users { get { return users; } }

        public AuthorizedUsers()
        {
           users = ReadFromFile.GetDataUser();
        }
        /*
        public void GetData()
        {
            var textUsers = File.ReadAllText("../../../registredUsers.json");
            users = JsonConvert.DeserializeObject<List<User>>(textUsers);
        }*/
        public User Contain(User logInUser, List<User> registredUsers)
        {
            string eMail = logInUser.Email;
            string password = logInUser.Password;

            foreach (User u in registredUsers)
            {
                if (eMail.Contains(u.Email) && password.Contains(u.Password))
                {
                    logInUser = u;
                    return logInUser;
                    // return;
                }
            }
            return null;
        }
        //public bool Equals(User user)
        //{
        //    foreach (var u in users)
        //    {
        //        if (user.Email == u.Email && user.Password == u.Password)
        //            return true;
        //    }
        //    return false;
        //}

        public event Action OnUpdated;

        public void AddNewUser(User user, AuthorizedUsers users)
        {
           /* if (users.Users == null)
            {
                users.Users = new List<User>();
            }
            */
            users.Users.Add(user);
            OnUpdated?.Invoke();
        }
        
        public AuthorizedUsers AddFavouriteStation(Station station, int id, AuthorizedUsers users)
        {
            User user = users.users[id];
            if (user.favouriteStation == null)
                {
                user.favouriteStation = new List<Station>();
                }
            
             if (!user.favouriteStation.Contains(station))
                users.users[id].favouriteStation.Add(station);



            //user.favouriteStation.Add(station);
            OnUpdated?.Invoke();

            return users;
            // here
        }
       
        /*
        public void DeleteFavouriteStation(Station station, User logInUser)
        {
            logInUser.favouriteStation.Remove(station);
            OnUpdated?.Invoke();
        }*/
    }
}
