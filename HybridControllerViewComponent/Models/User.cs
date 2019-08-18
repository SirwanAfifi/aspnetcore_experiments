using System.Collections.Generic;

namespace HybridControllerViewComponent.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public static class UserDataSource
    {
        public static IList<User> GetUsers()
        {
            var list = new List<User>();
            for (int i = 1; i < 50; i++)
            {
                list.Add(new User { Id = i * 2, Name = $"Name {++i}", LastName = $"LastName {++i}", Age = (++i * 2) / 2 });
            }
            return list;
        }
    }
}