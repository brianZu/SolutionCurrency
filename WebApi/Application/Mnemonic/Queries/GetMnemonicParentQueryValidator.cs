using FluentValidation;

namespace WebApi.Application.Mnemonic.Queries
{
    public class GetMnemonicParentQueryValidator : AbstractValidator<GetMnemonicParentQuery>
    {
        public GetMnemonicParentQueryValidator()
        {
            RuleFor(v => v.Mnemonic)
                .MaximumLength(5)
                .NotEmpty();
        }
    }
}
