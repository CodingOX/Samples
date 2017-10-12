using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySqlEF6.Models;

namespace MySqlEF6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MySqlData([FromServices] TestContext context)
        {
            var viewData = new Dictionary<string, string>();
            var td = context.TestData.ToList();
            foreach (var d in td)
            {
                viewData.Add(d.Id.ToString(), d.Data);
            }
            ViewBag.Database = context.Database.Connection.Database;
            ViewBag.DataSource = context.Database.Connection.DataSource;

            return View(viewData);
        }
    }
}
