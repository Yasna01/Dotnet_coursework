
using Mymoneymap.Abstraction;
using Mymoneymap.Model;
using Mymoneymap.Services.Interface;

namespace Mymoneymap.Services
{
    public class UserSevice : UserBase, IUser
    {
        private List<User> _users;

        public const string SeedUsername = "Yasna";
        public const string SeedPassword = "Dotnet";

        public UserSevice() 
        { 
            _users = LoadUsers();

            if (!_users.Any())
            {
                _users.Add(new User { UserName = SeedUsername, Password = SeedPassword });
                SaveUsers(_users);
            }
        }
        public bool Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return false; // Invalid input.
            }

            // Check if the username and password match any user in the list.
            return _users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
        
    }
    }
}
