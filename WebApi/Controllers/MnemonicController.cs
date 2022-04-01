using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Mnemonic.Queries;

namespace WebApi.Controllers
{
    public class MnemonicController : RestApiControllerBase
    {

        [HttpGet("{Mnemonic}", Name = "GetParentMnemonics")]
        public async Task<MnemonicDTO> GetParentMnemonics([FromRoute] GetMnemonicParentQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{ParentMnemonic}/detail/{ChildMnemonic}", Name = "GetChildMnemonic")]
        public async Task<MnemonicDetailDTO> GetChildMnemonic([FromRoute] GetMnemonicChildQuery query)
        {
            return await Mediator.Send(query);
        }

    }
}
