using DAL.TestTaskApi.Models;

namespace TestTaskApi.BLL.DTO
{
    public class BetDto
    {
        public int Id { get; set; }
        public decimal SumAmount { get; set; }
        public decimal SumVictory { get; set; }
        public DateTime ChangeDate { get; set; }
        public DateTime SettlementDate { get; set; }
    }
}
