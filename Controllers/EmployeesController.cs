using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrganizationChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrganizationChart.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            this._context = context;
        }

        public JsonResult Index()
        {
            var model = _context.Job_history
                .FromSqlRaw<XHR_Job_History>("Exec [XHR_ReportOrgan]")
                .ToList();
            return Json(model);
        }

        public static IEnumerable<Employees> BuildTree(Employees current, Employees[] allItems)
        {
            var childs = allItems.Where(c => c.pid == current.id).ToArray();
            foreach (var child in childs)
                child.children = BuildTree(child, allItems);
            current.children = childs;
            return childs;
        }

        public static IEnumerable<Users> BuildTreeUsers(Users current, Users[] allItems)
        {
            var childs = allItems.Where(c => c.pid == current.id).ToArray();
            foreach (var child in childs)
                child.children = BuildTreeUsers(child, allItems);
            current.children = childs;
            return childs;
        }

        //convert a json from the database to be recreated as a linked array json
        public ActionResult OrgJson()
        {
            var model = _context.employee
                .FromSqlRaw<Employees>("Exec [XHR_ReportOrgan]")
                .ToArray();

            var roots = model.Where(i => i.pid == null);
            foreach (var root in roots)
                BuildTree(root, model);

            var jsontr = JsonConvert.SerializeObject(roots, Formatting.Indented);

            return Json(roots);
        }

        public ActionResult ByUsers()
        {
            var model = _context.rootusers
                .FromSqlRaw<Users>("Exec [XHR_ReportUsers]")
                .ToArray();

            var roots = model.Where(i => i.pid == null);
            foreach (var root in roots)
                BuildTreeUsers(root, model);

            var jsontr = JsonConvert.SerializeObject(roots, Formatting.Indented);

            return Json(roots);
        }

        public ActionResult ByRegion()
        {
            var returnResults = new List<NameChildObject>();

            var uniqueRegions  = _context.table.Select(c => c.RegionString).Distinct();

            foreach (string region in uniqueRegions)
            {
                returnResults.Add(new NameChildObject() { name = region });

                var uniqueSubRegions = _context.table.
                                        Where(r => r.RegionString == region).
                                        Select(c => c.SubRegionString).Distinct();
                

                foreach (string  subRegion in uniqueSubRegions)
                {
                    var regionObject = returnResults.Find(row => row.name == region);

                    var countryInfo = (from row in _context.table
                                       where row.SubRegionString == subRegion
                                       group row by row.CountryString into g

                                       select new NameChildObject()
                                       {
                                           name = g.Key,
                                           title = g.Key,
                                           SubRegionString = g.Key,
                                           CountryString = g.Key,
                                           RegionString = g.Key,
                                           size = g.Count()
                                       });

                    regionObject.children.Add(new NameChildObject()
                    {
                        name = subRegion,
                        title = region,
                        children = countryInfo.ToList()
                    });

                }
            }
            return Json(returnResults);
        }

    }
}
