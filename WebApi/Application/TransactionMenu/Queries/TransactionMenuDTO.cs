using TMI.Library.Application.Core.Common.Mappings;
using WebApi.Domain.Entities.TransactionMenu;

namespace WebApi.Application.TransactionMenu.Queries
{
    public class TransactionMenuDTO : IMapFrom<ETrxMenu>
    {
        public string TransactionNumber { get; set; }
        public bool IsNewTransaction { get; set; }
        public string TransactionUrl { get; set; }

    }
}
