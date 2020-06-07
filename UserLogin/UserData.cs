using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {
        static private UserContext _userContext = new UserContext();
        static private List<User> _testUsers;
        static public List<User> TestUsers
        {
            get 
            {
                return _testUsers = new List<User>
                {
                    new User()
                    {
                        UserId = 1,
                        Username = "Platon",
                        Password = "Makovsky",
                        Role = (Int32)UserRoles.ADMIN,
                        ActiveTo = DateTime.MaxValue,
                        LastTimeLogged = DateTime.Now
                    },
                    new User()
                    {
                        UserId = 2,
                        Username = "Student1",
                        Password = "Some_pass",
                        FacultyNumber = "1234567890",
                        Role = (Int32)UserRoles.STUDENT,
                        ActiveTo = DateTime.MaxValue,
                        LastTimeLogged = DateTime.Now
                    },
                    new User()
                    {
                        UserId = 3,
                        Username = "Student2",
                        Password = "Another_pass",
                        FacultyNumber = "1234567891",
                        Role = (Int32)UserRoles.STUDENT,
                        ActiveTo = DateTime.MaxValue,
                        LastTimeLogged = DateTime.Now
                    }
                };
            }
            set { }
        }

        static public User IsUserPassCorrect(String username, String password)
        {
            User result = (from user in _userContext.Users where user.Username.Equals(username) && user.Password.Equals(password) select user).First();
            return result;
        }

        static public void SetUserActiveTo(string username, DateTime activeTo)
        {
            User foundUser = FindUserByUsername(username);
            if (foundUser != null)
            {
                foundUser.ActiveTo = activeTo;
                _userContext.SaveChanges();
                Logger.LogActivity("Changing activity of user " + username);
            }
        }

        static public void SetUserLastTimeLogged(string username, DateTime lastTimeLogged)
        {
            User foundUser = FindUserByUsername(username);
            if (foundUser != null)
            {
                foundUser.LastTimeLogged = lastTimeLogged;
                _userContext.SaveChanges();
                Logger.LogActivity("Changing last time user was logged");
            }
        }

        static public void AssignUserRole(string username, UserRoles newRole)
        {
            User foundUser = FindUserByUsername(username);
            if (foundUser != null)
            {
                foundUser.Role = Convert.ToInt32(newRole);
                _userContext.SaveChanges();
                Logger.LogActivity($"Chaging role of user {username}");
            }
        }

        static private User FindUserByUsername(string username)
        {
            User result = (from user in _userContext.Users where user.Username.Equals(username) select user).First();
            return result;
        }
    }
}
