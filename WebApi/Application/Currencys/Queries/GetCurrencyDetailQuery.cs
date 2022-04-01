using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMI.Library.Application.Core.Common.Exceptions;
using WebApi.Application.Common.Interfaces;

namespace WebApi.Application.Currencys.Queries
{
    public class GetCurrencyDetailQuery : IRequest<TransactionDTO>
    {
        public string Transaction { get; set; }
        public int AccountType { get; set; }
    }

    public class GetCurrencyDetailQueryHandler : IRequestHandler<GetCurrencyDetailQuery, TransactionDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCurrencyDetailQueryHandler> _logger;

        public GetCurrencyDetailQueryHandler(
          IApplicationDbContext context,
          IMapper mapper,
          ILogger<GetCurrencyDetailQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TransactionDTO> Handle(GetCurrencyDetailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCurrencyDetail({0},{1})", request.Transaction, request.AccountType);

            var currencys = await _context.CurrencyConfigurations
                      .Join(_context.Currencys, c => c.IdCurrency, m => m.IdCurrency,
                             (c, m) => new
                             {
                                 IdTransaction = c.IdTransaction,
                                 IdAccountType = c.IdAccountType,
                                 IdCurrency = m.IdCurrency,
                                 ParentMnemonic = m.ParentMnemonic,
                                 Mnemonic = m.Mnemonic,
                                 HostCode = m.HostCode,
                                 Text = m.Text
                             })
                      .Join(_context.Transactions, r => r.IdTransaction, t => t.IdTransaction,
                            (r, t) => new
                            {
                                IdTransaction = r.IdTransaction,
                                NumTransaction = t.NumTransaction,
                                TextTransaction = t.Text,
                                IdAccountType = r.IdAccountType,
                                IdCurrency = r.IdCurrency,
                                ParentMnemonic = r.ParentMnemonic,
                                Mnemonic = r.Mnemonic,
                                HostCode = r.HostCode,
                                Text = r.Text
                            })
                      .Where(r => r.NumTransaction == request.Transaction && r.IdAccountType == request.AccountType)
                      .Select(y => new
                      {
                          NumTransaction = y.NumTransaction,
                          TextTransaction = y.TextTransaction,
                          IdCurrency = y.IdCurrency,
                          ParentMnemonic = y.ParentMnemonic,
                          Mnemonic = y.Mnemonic,
                          HostCode = y.HostCode,
                          Text = y.Text
                      })
                      .ToListAsync();

            if (currencys.Count<= 0)
            {
              throw new NotFoundException("Not found Currencys");
            }
            else
            {
                TransactionDTO TransactionDTO = new TransactionDTO();
                List<CurrencyDetailDTO> ListCurrencys = new List<CurrencyDetailDTO>();
                string? NumTransaction = "";
                string? TextTransaction = "";

                foreach (var i in currencys)
                {
                    NumTransaction = i.NumTransaction;
                    TextTransaction = i.TextTransaction;
                    CurrencyDetailDTO dto = new CurrencyDetailDTO();
                    dto.IdCurrency = i.IdCurrency;
                    dto.ParentMnemonic = i.ParentMnemonic;
                    dto.Mnemonic = i.Mnemonic;
                    dto.HostCode = i.HostCode;
                    dto.Text = i.Text;
                    ListCurrencys.Add(dto);
                }
                TransactionDTO.NumTransaction = NumTransaction;
                TransactionDTO.Text = TextTransaction;
                TransactionDTO.CurrencyDetails = ListCurrencys;

                return TransactionDTO;
            }


        
        }
    }
}
