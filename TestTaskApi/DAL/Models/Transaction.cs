namespace DAL.TestTaskApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime ChangeDate { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
