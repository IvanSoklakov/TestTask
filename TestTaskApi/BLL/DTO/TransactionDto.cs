using DAL.TestTaskApi.Models;

namespace TestTaskApi.BLL.DTO
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime ChangeDate { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }

    }
}
