using TMI.Library.Application.Core.Common.Mappings;
using WebApi.Domain.Entities.Mnemonic;

namespace WebApi.Application.Mnemonic.Queries
{
    public class MnemonicDTO : IMapFrom<MnemonicMain>
    {
        public string Mnemonic { get; set; }
        public string Description { get; set; }

        public ICollection<MnemonicDetailDTO> MnemonicDetails { get; set; }

    }

    public class MnemonicDetailDTO : IMapFrom<MnemonicDetail>
    {
        public string Mnemonic { get; set; }

        public string? HostCode { get; set; }
        public string? Text { get; set; }
        public string? MaxChq { get; set; }
        public string? Moneda { get; set; }


        public string? Value { get; set; }
        public string? CodAgencia { get; set; }

    }
}
