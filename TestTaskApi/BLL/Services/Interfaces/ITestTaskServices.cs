using DAL.TestTaskApi.Models;
using TestTaskApi.BLL.DTO;
using TestTaskApi.BLL.Infrastructure;

namespace TestTaskApi.BLL.Services.Interfaces
{
    public interface ITestTaskServices
    {
        void InitialDataBase();


        decimal GetRecalculationBalance(RecalculationBalanceDto recalculationBalance);
        IEnumerable<PlayerStatisticDto> GetPlayerStatisticsReportByStatusType(PlayerStatisticsReportByDto playerStatisticsReportByStatusTypeDto);

        OperationResult AddPalyer(PlayerDto playerDto);
        OperationResult UpdatePalyer(PlayerDto playerDto);
        OperationResult DeletePalyer(int playerId);
        PlayerDto GetPlayer(int playerId);
        IEnumerable<PlayerDto> GetAllPlayers();
        OperationResult AddTransaction(TransactionDto transactionDto);
        OperationResult AddBet(BetDto betDto);
    }
}
