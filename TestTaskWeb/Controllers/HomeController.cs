using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using TestTaskWeb.DTO;
using TestTaskWeb.Infrastucture;
using TestTaskWeb.Models;

namespace TestTaskMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
             _configuration = configuration;
             _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sectionRequestName = "TestTaskApiUrl";
            var path = "api/TestTask/GetAllPlayers";
            var requester = new Requester(_configuration);
            var res = requester.GetRequest<List<PlayerDto>>(sectionRequestName, path).Result;
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
            if (player != null)
            {
                var sectionRequestName = "TestTaskApiUrl";
                var path = $"api/TestTask/AddPalyer";
                var requester = new Requester(_configuration);
                var res = requester.PostRequest<OperationResult>(sectionRequestName, path, player).Result;            
            }
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult EditPlayer(int id, string surname, string name, string patronumic, StatusTypeEnum status, decimal balance, string registrationDate)
        {
            var player = new PlayerDto
            {
                Id = id, 
                Surname = surname,
                Name = name,
                Patronymic = patronumic,
                Balance = balance,
                StatusType = status,
                RegistrationDate = DateTime.ParseExact(registrationDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            };
            return View(player);
        }

        [HttpPost]
        public IActionResult EditPlayer(PlayerDto player)
        {
            if (player != null)
            {
                var sectionRequestName = "TestTaskApiUrl";
                var path = $"api/TestTask/UpdatePalyer";
                var requester = new Requester(_configuration);
                var res = requester.PostRequest<OperationResult>(sectionRequestName, path, player).Result;
            }
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult DeletePlayer(int id)
        {
            var sectionRequestName = "TestTaskApiUrl";
            var path = $"api/TestTask/DeletePalyer?id={id}";
            var requester = new Requester(_configuration);
            var res = requester.GetRequest<OperationResult>(sectionRequestName, path).Result;
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult GetInfoPlayer(int id)
        {
            var sectionRequestName = "TestTaskApiUrl";
            var path = "api/TestTask/GetPlayer?id={id}";
            var requester = new Requester(_configuration);
            var res = requester.PostRequest<OperationResult>(sectionRequestName, path, id).Result;         
            return View(res);
        }

        [HttpGet]
        public IActionResult PlayerStatistics(bool betTypeFlag, StatusTypeEnum statusType = StatusTypeEnum.New)
        {
            var playerStatisticsReportByStatusType = new PlayerStatisticsReportByDto { BetTypeFlag = betTypeFlag, StatusType = statusType };

            var sectionRequestName = "TestTaskApiUrl";
            var path = "api/TestTask/GetPlayerStatisticsReport";
            var requester = new Requester(_configuration);                      
            return View(requester.PostRequest<IEnumerable<PlayerStatisticDto>>(sectionRequestName, path, playerStatisticsReportByStatusType).Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}