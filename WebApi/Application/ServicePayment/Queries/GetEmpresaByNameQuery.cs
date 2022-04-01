using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Common.Interfaces;

namespace WebApi.Application.ServicePayment.Queries
{
    public class GetEmpresaByNameQuery : IRequest<ICollection<EmpresaDTOWithOutDetail>>
    {
        public string? Name { get; set; }
    }

    public class GetEmpresaByNameQueryHandler : IRequestHandler<GetEmpresaByNameQuery, ICollection<EmpresaDTOWithOutDetail>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmpresaByNameQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<EmpresaDTOWithOutDetail>> Handle(GetEmpresaByNameQuery request, CancellationToken cancellationToken)
        {
            return await _context.Empresas
                .Where(x => x.Description.Contains(request.Name))
                .ProjectTo<EmpresaDTOWithOutDetail>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }

}
