using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Currencys.Queries;


namespace WebApi.Controllers
{
    public class CurrencyController : RestApiControllerBase
    {
        [HttpGet("{Transaction}/{AccountType}", Name = "GetCurrencys")]
        public async Task<TransactionDTO> GetCurrencys([FromRoute] GetCurrencyDetailQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
