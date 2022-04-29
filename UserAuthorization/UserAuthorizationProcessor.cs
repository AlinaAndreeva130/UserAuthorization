using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorization
{
    public class UserAuthorizationProcessor
    {
        private Dictionary<string, int> UserErrorAttemptDict;
        private List<User> UserList;

        public UserAuthorizationProcessor()
        {
            UserErrorAttemptDict = new Dictionary<string, int>();
            UserList = new List<User>();
            UserList.Add(new User("andreeva", "qwerty"));
        }

        public bool AuthorizeUser(string login, string password)
        {
            User findedUser = UserList.Find(x => x.Login.Equals(login));
            int incorrectAttempt = UserErrorAttemptDict.GetValueOrDefault(login, 0);
            
            if (findedUser == null || incorrectAttempt >= 3)
            {
                return false;
            }

            if(CriptoHelper.VerifyHashedPassword(findedUser.Password, password))
            {
                return true;
            } else
            {
                if (UserErrorAttemptDict.ContainsKey(login))
                {
                    UserErrorAttemptDict[login] = incorrectAttempt + 1;
                }
                else
                {
                    UserErrorAttemptDict.Add(login, incorrectAttempt + 1);
                }
                
                return false;
            }
        }


    }
}
