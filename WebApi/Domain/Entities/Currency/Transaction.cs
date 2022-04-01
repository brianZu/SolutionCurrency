using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities.Currency
{
    [Table("Transacttion")]
    public class Transaction
    {
            [Key]
            public int IdTransaction { get; set; }
            public string NumTransaction { get; set; }
            public string Text { get; set; }
            public ICollection<CurrencyConfiguration>? ConfigurationTransaction { get; set; }
            public ICollection<Currency>? CurrencyDetails { get; set; }

    }
}
