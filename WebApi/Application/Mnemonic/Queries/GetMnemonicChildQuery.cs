using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMI.Library.Application.Core.Common.Exceptions;
using WebApi.Application.Common.Interfaces;

namespace WebApi.Application.Mnemonic.Queries
{
    public class GetMnemonicChildQuery : IRequest<MnemonicDetailDTO>
    {
        public string ParentMnemonic { get; set; }
        public string ChildMnemonic { get; set; }
    }

    public class GetMnemonicChildQueryHandler : IRequestHandler<GetMnemonicChildQuery, MnemonicDetailDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMnemonicChildQueryHandler> _logger;

        public GetMnemonicChildQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            ILogger<GetMnemonicChildQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MnemonicDetailDTO> Handle(GetMnemonicChildQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("GetMnemonicChild({0}, {1})", request.ParentMnemonic, request.ChildMnemonic);

            var result = await _context.MnemonicDetails
              .Where(x => x.ParentMnemonic == request.ParentMnemonic && x.Mnemonic == request.ChildMnemonic)
              .ProjectTo<MnemonicDetailDTO>(_mapper.ConfigurationProvider)
              .SingleOrDefaultAsync();

            if (result == null)
                throw new NotFoundException("Not found Mnemonic");

            return result;
        }

    }

}
