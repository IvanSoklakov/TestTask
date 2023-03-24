using DAL.TestTaskApi.Models;

namespace TestTaskApi.BLL.DTO
{
    public class PlayerStatisticDto
    {
        public  PlayerDto Player { get; set; }
        public decimal SumAllTransactions { get; set; }
        public decimal SumAllBets { get; set; }
    }
}
