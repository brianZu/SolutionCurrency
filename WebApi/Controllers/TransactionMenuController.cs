using Microsoft.AspNetCore.Mvc;
using WebApi.Application.TransactionMenu.Queries;

namespace WebApi.Controllers
{
    public class TransactionMenuController : RestApiControllerBase
    {

        [HttpGet("{TransactionNumber}")]
        public async Task<TransactionMenuDTO> GetMenu([FromRoute] GetTransactionMenuQuery query)
        {
            return await Mediator.Send(query);
        }

    }
}
