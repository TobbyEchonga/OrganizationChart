using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.Models
{
    public class NameChildObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int size { get; set; }
        public string RegionString { get; set; }
        public string SubRegionString { get; set; }
        public string CountryString { get; set; }
        public List<NameChildObject> children { get; set; }
        public NameChildObject()
        {
            children = new List<NameChildObject>();
        }
    }
}
