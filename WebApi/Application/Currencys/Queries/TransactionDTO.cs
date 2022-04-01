using TMI.Library.Application.Core.Common.Mappings;
using WebApi.Domain.Entities.Currency;

namespace WebApi.Application.Currencys.Queries
{
    public class TransactionDTO : IMapFrom<Transaction>
    {
        public string? NumTransaction { get; set; }

        public string? Text { get; set; }
        public ICollection<CurrencyDetailDTO>? CurrencyDetails { get; set; }
    }

    public class CurrencyDetailDTO : IMapFrom<Currency>
    {
        public int IdCurrency { get; set; }
        public string? ParentMnemonic { get; set; }
        public string? Mnemonic { get; set; }
        public string? HostCode { get; set; }
        public string? Text { get; set; }
    }
}
