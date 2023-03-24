namespace TestTaskWeb.DTO
{
    public class BetDto
    {
        public int Id { get; set; }
        public decimal SumAmount { get; set; }
        public decimal SumVictory { get; set; }
        public DateTime ChangeDate { get; set; }
        public DateTime SettlementDate { get; set; }
        public int PlayerId { get; set; }
        public PlayerDto Player { get; set; }
    }
}
