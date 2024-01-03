using Microsoft.AspNetCore.Mvc;
using RMV.DriverExaminer.Services.Interfaces;
using RMV.DriverExaminer.Services.Models;
using RMV.DriverExaminer.Services.Utilities;
using System.Diagnostics;

namespace RMV.DriverExaminer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExamDetailsService _examDetailsService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IExamDetailsService examDetailsService, ILogger<HomeController> logger)
        {
            _examDetailsService = examDetailsService ?? throw new ArgumentNullException(nameof(examDetailsService)); 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            //var result = await _examDetailsService.GetExamData("");

            //var model = result ?? throw new ApplicationException(); ////Global Error handaling check
            //return View(result);
            return View(new PublicApiModel());

        }
        public async Task<IActionResult> Privecy()
        {
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
