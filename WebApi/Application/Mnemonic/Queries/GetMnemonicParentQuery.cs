using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Common.Interfaces;

namespace WebApi.Application.Mnemonic.Queries
{
    public class GetMnemonicParentQuery : IRequest<MnemonicDTO>
    {
        public string? Mnemonic { get; set; }
    }

    public class GetMnemonicParentQueryHandler : IRequestHandler<GetMnemonicParentQuery, MnemonicDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMnemonicParentQueryHandler> _logger;

        public GetMnemonicParentQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            ILogger<GetMnemonicParentQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MnemonicDTO> Handle(GetMnemonicParentQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetMnemonicParent({0})", request.Mnemonic);

            return await _context.Mnemonics
              .Include(d => d.MnemonicDetails)
              .Where(x => x.Mnemonic == request.Mnemonic)
              .ProjectTo<MnemonicDTO>(_mapper.ConfigurationProvider)
              .SingleOrDefaultAsync();
        }
    }
}
