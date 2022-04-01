using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities.ServicePayment
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public string Mnemonic { get; set; }
        public string RubroMnemonic { get; set; }
        public string HostCode { get; set; }
        public string Description { get; set; }
        public ICollection<Servicio> Servicios { get; set; }

    }
}
