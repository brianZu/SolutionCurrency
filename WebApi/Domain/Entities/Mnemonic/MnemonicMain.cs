using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities.Mnemonic
{
    [Table("Lista")]
    public class MnemonicMain
    {
        [Key]
        public string? Mnemonic { get; set; }

        public string? Description { get; set; }

        public ICollection<MnemonicDetail>? MnemonicDetails { get; set; }
    }
}
