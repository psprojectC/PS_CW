using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private String _username;
        private String _password;
        private String _errorMsg;
        private ActionOnError _actionOnError;
        static public string currentUserUsername;
        static public UserRoles currentUserRole;

        public delegate void ActionOnError(string errorMsg);

        public LoginValidation(String username,
            String password,
            ActionOnError actionOnError)
        {
            this._username = username;
            this._password = password;
            this._actionOnError = actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            currentUserRole = UserRoles.ANONYMOUS;
            if (isEmptyInput(this._username))
            {
                this._errorMsg = "No username has been provided.";
                this._actionOnError(this._errorMsg);
                return false;
            }
            else if (isEmptyInput(this._password))
            {
                this._errorMsg = "No password has been provided.";
                this._actionOnError(this._errorMsg);
                return false;
            }
            else if (isUnderFiveSymbols(this._username))
            {
                this._errorMsg = "Bad username. Should be above 5 symbols.";
                this._actionOnError(this._errorMsg);
                return false;
            }
            else if (isUnderFiveSymbols(this._password))
            {
                this._errorMsg = "Bad password. Should be above 5 symbols.";
                this._actionOnError(this._errorMsg);
                return false;
            }
            else 
            {
                List<User> users = UserData.TestUsers;
                user = UserData.IsUserPassCorrect(this._username, this._password);
                if (user == null)
                {
                    this._errorMsg = "No user found.";
                    this._actionOnError(this._errorMsg);
                    return false;
                }
                currentUserUsername = user.Username;
                currentUserRole = (UserRoles)user.Role;
                Logger.LogActivity("Successfully logined.");
                return true;
            }
        }
        private bool isEmptyInput(String input) => input.Equals(String.Empty);
        private bool isUnderFiveSymbols(String input) => input.Length < 5;
        public override string ToString() => base.ToString();
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
