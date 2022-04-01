using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities.Currency
{
    [Table("CurrencyConfiguration")]
    public class CurrencyConfiguration
    {
        public int IdConfiguration { get; set; }
        public AccountType? AccountType { get; set; }
        public int? IdAccountType { get; set; }
        public Transaction? Transaction { get; set; }
        public int? IdTransaction { get; set; }
        public Currency? Currency { get; set; }
        public int? IdCurrency { get; set; }
    }
}
