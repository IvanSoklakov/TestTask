using AutoMapper;
using DAL.TestTaskApi.Models;
using System.Globalization;
using TestTaskApi.BLL.DTO;
using TestTaskApi.BLL.Infrastructure;
using TestTaskApi.BLL.Services.Interfaces;
using TestTaskApi.DAL.Interfaces;

namespace TestTaskApi.BLL.Services
{
    public class TestTaskServices : ITestTaskServices
    {
        private readonly ITestTaskUnitOfWork _repository;
        private readonly IMapper _mapper;

        public TestTaskServices(ITestTaskUnitOfWork repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region InitializationDataBase
        public void InitialDataBase()
        {
            var players = new List<Player>
            {
                new Player {
                    Id = 1, Surname = "Иванов", Name ="Иван", Patronymic = "Иваныч", Balance = 11000, RegistrationDate = DateTime.UtcNow, StatusType = StatusTypeEnum.New,
                    Bets = new List<Bet>
                    {
                      new Bet {SumVictory = 1000, Amount = 500, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 1, },
                      new Bet {SumVictory = 8000, Amount = 4000, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 1}
                    },
                    Transactions = new List<Transaction>
                    {
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 1},
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 1}
                    },
                },
                new Player {
                    Id = 2, Surname = "Петров", Name ="Петр", Patronymic = "Петрович", Balance = 5500, RegistrationDate = DateTime.ParseExact("2022.12.21","yyyy.MM.dd", CultureInfo.InvariantCulture), StatusType = StatusTypeEnum.Bad,
                    Bets = new List<Bet>
                    {
                      new Bet {SumVictory = 500, Amount = 250, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 2},
                      new Bet {SumVictory = 3000, Amount = 500, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 2}
                    },
                    Transactions = new List<Transaction>
                    {
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 2},
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 2}
                    },
                },
                new Player {
                    Id = 3, Surname = "Дмитров", Name ="Дмитрий", Patronymic = "Дмитрич", Balance = 3500, RegistrationDate = DateTime.UtcNow, StatusType = StatusTypeEnum.New,
                    Bets = new List<Bet>
                    {
                      new Bet {SumVictory = 700, Amount = 100, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 3},
                      new Bet {SumVictory = 800, Amount = 500, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 3},
                    },
                    Transactions = new List<Transaction>
                    {
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 3},
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 3},
                    },


                },
                new Player {
                    Id = 4, Surname = "Алексеенко", Name ="Алексей", Patronymic = "Алексеевич", Balance = 11000, RegistrationDate = DateTime.UtcNow, StatusType = StatusTypeEnum.New,
                    Bets = new List<Bet>
                    {
                      new Bet {SumVictory = 0, Amount =1000, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 4},
                      new Bet {SumVictory = 10000, Amount = 1000, ChangeDate = DateTime.Now, SettlementDate = DateTime.Now , PlayerId = 4},
                    },
                    Transactions = new List<Transaction>
                    {
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 4},
                      new Transaction {TransactionType = TransactionTypeEnum.Replenish, Sum = 1000, ChangeDate = DateTime.Now, PlayerId = 4},
                    },
                }
            };
            _repository.GetRepository<Player>().AddRange(players);
            _repository.SaveChanges();
        }
        #endregion

        public OperationResult AddPalyer(PlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(source: playerDto);
            player.StatusType = StatusTypeEnum.New;
            player.RegistrationDate = DateTime.UtcNow;
            _repository.GetRepository<Player>().Add(player);
            return OperationResult.CreateSuccessResult();
        }

        public OperationResult UpdatePalyer(PlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(source: playerDto);
            _repository.GetRepository<Player>().Update(player);
            return OperationResult.CreateSuccessResult();
        }

        public OperationResult DeletePalyer(int playerId)
        {
            _repository.GetRepository<Player>().Delete(x =>x.Id == playerId);
            return OperationResult.CreateSuccessResult();
        }

        public PlayerDto GetPlayer(int playerId)
        {
            var player = _repository.GetRepository<Player>().Where(x => x.Id == playerId);         
            return _mapper.Map<PlayerDto>(source: player);
        }

        public IEnumerable<PlayerDto> GetAllPlayers()
        {
            var player = _repository.GetRepository<Player>().Where();
            return _mapper.Map<IEnumerable<PlayerDto>>(source: player);
        }

        public OperationResult AddTransaction(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(source: transactionDto);
            _repository.GetRepository<Transaction>().Add(transaction);
            return OperationResult.CreateSuccessResult();
        }

        public OperationResult AddBet(BetDto betDto)
        {
            var bet = _mapper.Map<Bet>(source: betDto);
            _repository.GetRepository<Bet>().Add(bet);
            return OperationResult.CreateSuccessResult();
        }

        public decimal GetRecalculationBalance(RecalculationBalanceDto recalculationBalance)
        {
            var player = _repository.GetRepository<Player>().SingleOrDefault(x => x.Id == recalculationBalance.PlayerId);        

            switch (recalculationBalance.TransactionTypeEnum)
            {
                case TransactionTypeEnum.Replenish:
                    {
                        player.Balance += recalculationBalance.TransactionAmount;
                        var newTransaction =
                            new TransactionDto
                            {
                                TransactionType = recalculationBalance.TransactionTypeEnum,
                                Sum = recalculationBalance.TransactionAmount,
                                ChangeDate = DateTime.Now,
                            };

                        AddTransaction(newTransaction);
                        _repository.GetRepository<Player>().Update(player);
                        _repository.SaveChanges();
                        break;
                    }
                case TransactionTypeEnum.Withdraw:
                    {
                        var balance = player.Balance - recalculationBalance.TransactionAmount;
                        if (balance > -1)
                        {
                            player.Balance = balance;
                        }
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                        break;
                    }
            }  
            return player.Balance;
        }

        public IEnumerable<PlayerStatisticDto> GetPlayerStatisticsReportByStatusType(PlayerStatisticsReportByDto playerStatisticsReportByStatusTypeDto)
        {
            var result = new List<PlayerStatisticDto>();
            var players = _repository.GetRepository<Player>().WhereWithInclude(x => x.StatusType == playerStatisticsReportByStatusTypeDto.StatusType, x=>x.Bets, x=>x.Transactions).ToList();

            foreach (var player in players)
            {
                var SumAllTransactions = player.Transactions.Where(x => x.TransactionType == TransactionTypeEnum.Replenish).Sum(x => x.Sum ) - player.Transactions.Where(x => x.TransactionType == TransactionTypeEnum.Withdraw).Sum(x => x.Sum);
                var SumAllBets = player.Bets.Sum(x => x.Amount);
                if (playerStatisticsReportByStatusTypeDto.BetTypeFlag && SumAllTransactions < SumAllBets)
                {
                    result.Add(
                        new PlayerStatisticDto
                        {
                            Player = _mapper.Map<PlayerDto>(source: player),
                            SumAllBets = SumAllBets,
                            SumAllTransactions = SumAllTransactions
                        });
                }
                else if (!playerStatisticsReportByStatusTypeDto.BetTypeFlag)
                {
                    result.Add(
                       new PlayerStatisticDto
                       {
                           Player = _mapper.Map<PlayerDto>(source: player),
                           SumAllBets = SumAllBets,
                           SumAllTransactions = SumAllTransactions
                       });
                }
            }
            return result;
        }
    }
}
