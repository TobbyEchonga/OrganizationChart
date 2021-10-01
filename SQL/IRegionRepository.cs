using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.Models
{
    public interface IRegionRepository
    {
        IEnumerable<NameChildObject> GetAllEntities();   
    }
}
