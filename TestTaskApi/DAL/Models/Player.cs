namespace DAL.TestTaskApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public decimal Balance { get; set; }
        public DateTime RegistrationDate { get; set; }
        public StatusTypeEnum StatusType { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Bet> Bets { get; set; }
    }
}
