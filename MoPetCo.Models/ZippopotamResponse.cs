using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    public class ZippopotamResponse
    {
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string CountryAbbreviation { get; set; }
        public List<Place> Places { get; set; }
    }

    public class Place
    {
        public string PlaceName { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
