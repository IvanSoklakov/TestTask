using Microsoft.AspNetCore.Mvc;
using NLog;
using TestTaskApi.BLL.DTO;
using TestTaskApi.BLL.Services.Interfaces;

namespace TestTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTaskController : Controller
    {
        private readonly NLog.ILogger _logger;
        private readonly ITestTaskServices _services;
        public TestTaskController(ITestTaskServices services )
        {
            _logger = LogManager.GetCurrentClassLogger(typeof(TestTaskController));
            _services = services;
        }

        [HttpGet("GetAllPlayers")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllPlayers()
        {
            try
            {
                var result = _services.GetAllPlayers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        

        [HttpGet("InitialDataBase")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult InitialDataBase()
        {
            try
            {
                _services.InitialDataBase();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("GetRecalculationBalance")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public IActionResult GetRecalculationBalance([FromBody] RecalculationBalanceDto recalculationBalance)
        {
            try
            {
                var result = _services.GetRecalculationBalance(recalculationBalance);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("GetPlayerStatisticsReport")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPlayerStatisticsReport([FromBody] PlayerStatisticsReportByDto playerStatisticsReportByStatusType)
        {
            try
            {
                var result = _services.GetPlayerStatisticsReportByStatusType(playerStatisticsReportByStatusType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddPalyer")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddPalyer([FromBody] PlayerDto playerDto)
        {
            try
            {
                var res = _services.AddPalyer(playerDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("UpdatePalyer")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdatePalyer([FromBody] PlayerDto playerDto)
        {
            try
            {
                var result = _services.UpdatePalyer(playerDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("DeletePalyer")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeletePalyer(int Id)
        {
            try
            {
                var result = _services.DeletePalyer(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddTransaction")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddTransaction([FromBody] TransactionDto transactionDto)
        {
            try
            {
                var result = _services.AddTransaction(transactionDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddBet")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddBet([FromBody] BetDto betDto)
        {
            try
            {
                var result = _services.AddBet(betDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetPlayer")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPlayer([FromQuery]  int Id)
        {
            try
            {
                var result = _services.GetPlayer(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}