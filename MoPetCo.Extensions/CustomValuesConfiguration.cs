using Microsoft.Extensions.Configuration;
using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Extensions
{
    public class CustomValuesConfiguration
    {
        private readonly List<CustomValues> _customValues;

        public List<CustomValues> CustomValues => _customValues;

        public CustomValuesConfiguration(IConfiguration configuration)
        {
            var customValuesSection = configuration.GetSection("CustomValues").GetChildren();
            _customValues = customValuesSection.Select(item => new CustomValues
            {
                Name = item["Name"],
                Values = item.GetSection("Values").GetChildren()
                    .ToDictionary(val => val.Key, val => val.Value)
            }).ToList();
        }

        public CustomValues GetCustomValueByName(string name)
        {
            return _customValues.FirstOrDefault(cv => cv.Name == name);
        }
    }
}
