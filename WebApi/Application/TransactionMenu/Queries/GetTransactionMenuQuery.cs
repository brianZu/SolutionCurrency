using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMI.Library.Application.Core.Common.Exceptions;
using WebApi.Application.Common.Interfaces;

namespace WebApi.Application.TransactionMenu.Queries
{
    public class GetTransactionMenuQuery : IRequest<TransactionMenuDTO>
    {
        public string TransactionNumber { get; set; }
    }

    public class GetTransactionMenuQueryHandler : IRequestHandler<GetTransactionMenuQuery, TransactionMenuDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTransactionMenuQueryHandler> _logger;

        public GetTransactionMenuQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            ILogger<GetTransactionMenuQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TransactionMenuDTO> Handle(GetTransactionMenuQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetTransactionMenuQuery({0})", request.TransactionNumber);

            var menu = await _context
              .TransactionMenus
              .Where(x => x.TransactionNumber == request.TransactionNumber)
              .ProjectTo<TransactionMenuDTO>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync();

            if (menu == null)
                throw new NotFoundException("Not found Menu");

            return menu;
        }
    }

}
