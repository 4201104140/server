using Microsoft.AspNetCore.Mvc;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class LogsController : Controller
    {
        private const string Database = "Diagnostics";
        private const string Collection = "Logs";

        //public async Task<IActionResult> Index(string cursor = null, int count = 50,
        //    LogEventLevel? level = null, string project = null, DateTime? start = null, DateTime? end = null)
        //{
        //    var 
        //}
    }
}
