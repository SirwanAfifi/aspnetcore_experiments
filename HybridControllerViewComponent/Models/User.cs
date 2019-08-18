using System.Collections.Generic;
using System.Linq;

namespace HybridControllerViewComponent.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class UserRepository
    {
        private readonly IList<User> users = new List<User>();

        public UserRepository()
        {
            for (int i = 1; i < 50; i++)
            {
                users.Add(new User { Id = i * 2, Name = $"Name {++i}", LastName = $"LastName {++i}", Age = (++i * 2) / 2 });
            }
        }
        public IList<User> GetUsers()
        {
            return users;
        }

        public void Edit(User user)
        {
            var selectedUser = users.FirstOrDefault(u => u.Id == user.Id);
            selectedUser.Id = user.Id;
            selectedUser.Name = user.Name;
            selectedUser.LastName = user.LastName;
            selectedUser.Age = user.Age;
        }
    }
}