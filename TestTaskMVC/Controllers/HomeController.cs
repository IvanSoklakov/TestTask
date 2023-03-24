using DAL.TestTaskApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;
using TestTaskApi.BLL.DTO;
using TestTaskApi.BLL.Services.Interfaces;
using TestTaskMVC.Models;

namespace TestTaskMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestTaskServices _services;
        public HomeController(ILogger<HomeController> logger, ITestTaskServices services)
        {
            _services = services;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var res = _services.GetAllPlayers();
            return View(res);
        }


        [HttpGet]
        public IActionResult AddPlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayer(PlayerDto player)
        {
            if(player!=null)
            {
                _services.AddPalyer(player);
            }    
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult EditPlayer(Player to )
        {
            var player = new PlayerDto 
            { 
                //Id = id, 
                //Surname = surname,
                //Name = name,
                //Patronymic = patronumic,
                //Balance = balance,
                //StatusType = (StatusTypeEnum)statusType,
                //RegistrationDate = registrationDate,
            };
            return View(player);
        }

        [HttpPost]
        public IActionResult EditPlayer(PlayerDto player)
        {
            if (player != null)
            {
                _services.UpdatePalyer(player);
            }
            return Redirect("/Home/Index");
        }

        public IActionResult DeletePlayer(int id)
        {
            _services.DeletePalyers(new List<int>{ id });
            return Redirect("/Home/Index");
        }

        public IActionResult GetInfoPlayer(int id)
        {
            var res = _services.GetPlayers(new List<int> { id });
            return View(res);
        }

        public IActionResult PlayerStatistics(bool betTypeFlag, int statusType)
        {
            if( betTypeFlag || statusType != default)
            {
                return View(_services.GetPlayerStatisticsReportByStatusType(betTypeFlag, (StatusTypeEnum)statusType));
            }
            return View(_services.GetPlayerStatisticsReportByStatusType());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}