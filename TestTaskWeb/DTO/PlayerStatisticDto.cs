namespace TestTaskWeb.DTO
{
    public class PlayerStatisticDto
    {
        public  PlayerDto Player { get; set; }
        public decimal SumAllTransactions { get; set; }
        public decimal SumAllBets { get; set; }
    }
}
