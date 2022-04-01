using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Common.Interfaces;

namespace WebApi.Application.ServicePayment.Queries
{
    public  class GetEmpresaQuery : IRequest<EmpresaDTO>
    {
        public string? Mnemonic { get; set; }
    }

    public class GetEmpresaQueryHandler : IRequestHandler<GetEmpresaQuery, EmpresaDTO>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmpresaQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<EmpresaDTO> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Empresas
                .Where(x => x.Mnemonic == request.Mnemonic)
                .ProjectTo<EmpresaDTO>(_mapper.ConfigurationProvider)
                .FirstAsync();
        }
    }
}
