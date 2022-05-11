using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TownGameBot.Models
{
    public class CityList
    {
        public List<CityModel> CityModels { get; set; } = new List<CityModel> { new CityModel { City = "London"},
                                                                                new CityModel { City = "Paris"},
                                                                                new CityModel { City = "Oslo"},
                                                                                new CityModel { City = "Istanbul"},
                                                                                new CityModel { City = "Lisbon"}
                                                                              };
    }
}
