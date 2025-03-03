using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPaulMain.Model
{
    public class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public class UserList
    {
        public static List<User> ManList = new List<User>
        {
            new User("Отсутствует"),
            new User("Иван"),
            new User("Василий"),
            new User("Генадий"),
        };

        public static User? FindByString(string Name)
        {
            User? toReturn = null;
            for(int i = 0; i <= ManList.Count; i++)
            {
                if (ManList[i].ToString() == Name) 
                { 
                    toReturn = ManList[i];
                    break;
                    //test
                }
            }
            return toReturn;
        }
    }
}
