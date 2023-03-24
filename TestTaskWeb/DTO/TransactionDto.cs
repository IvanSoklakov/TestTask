using TestTaskWeb.Models;

namespace TestTaskWeb.DTO
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime ChangeDate { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public int PlayerId { get; set; }
        public PlayerDto Player { get; set; }
    }
}
