using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.Models
{
    public class Employees
    {
        public string RecordId { get; set; }
        public string id { get; set; }
        public string pid { get; set; }
        public string title { get; set; }
        public string tags { get; set; }
        public string className { get; set; }
        public string name { get; set; }
        public IEnumerable<Employees> children { get; set; }
        public bool ShouldSerializeitems()
        {
            return children.Any();
        }
    }
}
