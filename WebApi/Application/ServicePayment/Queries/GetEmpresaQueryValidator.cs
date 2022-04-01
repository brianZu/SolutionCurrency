using FluentValidation;

namespace WebApi.Application.ServicePayment.Queries
{

    public class GetEmpresaQueryValidator : AbstractValidator<GetEmpresaQuery>
    {
        public GetEmpresaQueryValidator()
        {
            RuleFor(v => v.Mnemonic)
                .MaximumLength(8)
                .NotEmpty();
        }
    }
}
