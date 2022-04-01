using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities.Mnemonic
{
	[Table("DetalleLista")]
	public class MnemonicDetail
	{
		[Key]
		public Guid Id { get; set; }

		public MnemonicMain Parent { get; set; }

		public string ParentMnemonic { get; set; }

		public string Mnemonic { get; set; }


		public string? HostCode { get; set; }
		public string? Text { get; set; }

		public string? MaxChq { get; set; }

		public string? Moneda { get; set; }
		public string? Plaza { get; set; }
		public string? Cuenta { get; set; }
		public string? Swift { get; set; }
		public string? FormatoGenerico { get; set; }
		public string? FormatoPropio { get; set; }
		public string? ShortDesc { get; set; }
		public string? CodMon { get; set; }
		public string? TipPer { get; set; }
		public string? TextoRefrendo { get; set; }
		public string? IndCV { get; set; }
		public string? IndEntregar { get; set; }
		public string? IndITF { get; set; }
		public string? IndPinPad { get; set; }
		public string? IndFirma { get; set; }
		public string? IndCargo { get; set; }
		public string? IndAbono { get; set; }
		public string? MonCV { get; set; }
		public string? Descripcion { get; set; }
		public string? TituloPantalla { get; set; }
		public string? Related { get; set; }
		public string? TipoChqRec { get; set; }
		public string? CuotaMes { get; set; }
		public string? Desde { get; set; }
		public string? Hasta { get; set; }
		public string? VentaInf { get; set; }
		public string? VentaSup { get; set; }
		public string? CompraInf { get; set; }
		public string? CompraSup { get; set; }
		public string? Calculado { get; set; }
		public string? Value { get; set; }
		public string? TranName { get; set; }
		public string? CodAgencia { get; set; }
		public string? Tarifa { get; set; }
		public string? Tienda { get; set; }
		public string? Moneda01 { get; set; }
		public string? Moneda02 { get; set; }
		public string? Moneda03 { get; set; }
		public string? Moneda04 { get; set; }
		public string? Moneda05 { get; set; }
		public string? Moneda06 { get; set; }
		public string? Moneda07 { get; set; }
		public string? Moneda08 { get; set; }
		public string? Moneda09 { get; set; }
		public string? Frecuencia { get; set; }
		public string? NumCalifMayor { get; set; }
		public string? Factor { get; set; }
		public string? HoraInicio { get; set; }
		public string? MasMe { get; set; }
		public string? permiteEfectivo { get; set; }
		public string? Tipo { get; set; }
		public string? MostrarCampo { get; set; }
		public string? Codpos { get; set; }
		public string? Obs { get; set; }

	}
}
