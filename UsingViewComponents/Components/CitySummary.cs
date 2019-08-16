using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        public string Invoke()
        {
            return $"{City.Cities().Count()} cities, "
            + $"{City.Cities().Sum(c => c.Population)} people";
        }
    }
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public static IList<City> Cities()
        {
            return new List<City>
                {
                    new City { Name = "Tehran", Population = 12000000 },
                    new City { Name = "Sanandaj", Population = 600000 },
                };
        }
    }
}