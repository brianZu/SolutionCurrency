using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ServicePayment.Queries;

namespace WebApi.Controllers
{
    public class EmpresaController : RestApiControllerBase
    {
        [HttpGet("{Mnemonic}", Name = "GetEmpresa")]
        public async Task<EmpresaDTO> GetEmpresa([FromRoute] GetEmpresaQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(Name = "GetEmpresaByName")]
        public async Task<ICollection<EmpresaDTOWithOutDetail>> GetEmpresaByName([FromQuery] GetEmpresaByNameQuery query)
        {
            return await Mediator.Send(query);
        }

    }
}
