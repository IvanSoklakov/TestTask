using DAL.TestTaskApi.Models;

namespace TestTaskApi.BLL.DTO
{
    public class RecalculationBalanceDto
    {
         public int PlayerId { get; set; }
         public decimal TransactionAmount { get; set; }
         public TransactionTypeEnum TransactionTypeEnum { get; set; }
    }
}
