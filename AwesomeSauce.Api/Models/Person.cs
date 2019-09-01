using System.Collections.Generic;

namespace AwesomeSauce.Api.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Person[] Friends { get; set; } = new Person[] { };
    }

    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetOne(int id);
    }
}