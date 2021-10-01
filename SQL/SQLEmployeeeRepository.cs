using OrganizationChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.SQL
{
    public class SQLEmployeeeRepository : IEmployye
    {
        private readonly EmployeeDbContext context;

        public SQLEmployeeeRepository(EmployeeDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Users> GetEntities()
        {
            return context.rootusers;
        }
    }
}
