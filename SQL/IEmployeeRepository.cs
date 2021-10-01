using OrganizationChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.SQL
{
    public interface IEmployye
    {
        IEnumerable<Users> GetEntities();
    }
}
