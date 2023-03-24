namespace DAL.TestTaskApi.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal SumVictory { get; set; }
        public DateTime ChangeDate { get; set; }
        public DateTime SettlementDate { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
