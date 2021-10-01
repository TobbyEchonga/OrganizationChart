using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.Models
{
    public class SQLNameRepository : IRegionRepository
    {
        private readonly EmployeeDbContext context;
            
        public SQLNameRepository(EmployeeDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<NameChildObject> GetAllEntities()
        {
            return context.table;
        }
    }
}
