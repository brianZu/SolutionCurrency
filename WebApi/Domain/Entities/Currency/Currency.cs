using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities.Currency
{
    [Table("Currency")]
    public class Currency
    {
            [Key]
            public int IdCurrency { get; set; }
            public string? ParentMnemonic { get; set; }
            public string? Mnemonic { get; set; }
            public string? HostCode { get; set; }
            public string? Text { get; set; }
            public ICollection<CurrencyConfiguration>? ConfigurationCurrency { get; set; }
    }
}
