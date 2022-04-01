using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities.ServicePayment
{
	[Table("Servicio")]
	public class Servicio
	{
		public string EmpresaMnemonic { get; set; }

		public Empresa Empresa { get; set; }

		[Key]
		public string Mnemonic { get; set; }
		public string HostCode { get; set; }
		public string Description { get; set; }
		public string MODINFORM { get; set; }
		public string NUMCAMDEUDOR { get; set; }
		public string NOMVARDEUDOR1 { get; set; }
		public string LONCODEUDOR1 { get; set; }
		public string INDNUMDEUDOR1 { get; set; }
		public string NOMVARDEUDOR2 { get; set; }
		public string LONCODEUDOR2 { get; set; }
		public string INDNUMDEUDOR2 { get; set; }
		public string NOMVARDEUDOR3 { get; set; }
		public string LONCODEUDOR3 { get; set; }
		public string INDNUMDEUDOR3 { get; set; }
		public string INDTIPOTRAMIT { get; set; }
		public string INDTIPOMONEDA { get; set; }

	}
}
