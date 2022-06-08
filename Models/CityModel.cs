using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TownGameBot.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public bool NamedCity { get; set; } = false;
    }
}
