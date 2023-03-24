using AutoMapper;
using DAL.TestTaskApi.Models;
using TestTaskApi.BLL.DTO;

namespace TestTaskApi.BLL.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bet, BetDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Transaction, TransactionDto>();

            CreateMap<BetDto, Bet>();
            CreateMap<PlayerDto, Player>();
            CreateMap<TransactionDto, Transaction>();
        }
    }
}
