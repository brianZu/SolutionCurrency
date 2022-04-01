using TMI.Library.Application.Core.Common.Mappings;
using WebApi.Domain.Entities.ServicePayment;

namespace WebApi.Application.ServicePayment.Queries
{
    public class EmpresaDTO : IMapFrom<Empresa>
    {
        public string Mnemonic { get; set; }
        public string RubroMnemonic { get; set; }
        public string HostCode { get; set; }
        public string Description { get; set; }

        public ICollection<ServicioDTO> Servicios { get; set; }

    }

    public class EmpresaDTOWithOutDetail : IMapFrom<Empresa>
    {
        public string Mnemonic { get; set; }
        public string RubroMnemonic { get; set; }
        public string HostCode { get; set; }
        public string Description { get; set; }
    }
}
