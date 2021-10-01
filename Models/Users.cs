using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.Models
{
    public class Users
    {
        public string id { get; set; }
        public string pid { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public IEnumerable<Users> children { get; set; }
        public bool ShouldSerializeitems()
        {
            return children.Any();
        }

    }
}
