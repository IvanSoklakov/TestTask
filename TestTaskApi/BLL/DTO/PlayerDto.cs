using DAL.TestTaskApi.Models;

namespace TestTaskApi.BLL.DTO
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public decimal Balance { get; set; }
        public DateTime RegistrationDate { get; set; }
        public StatusTypeEnum StatusType { get; set; }
    }
}
