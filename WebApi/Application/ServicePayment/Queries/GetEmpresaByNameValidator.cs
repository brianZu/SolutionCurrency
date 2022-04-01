using FluentValidation;

namespace WebApi.Application.ServicePayment.Queries
{
    public class GetEmpresaByNameValidator : AbstractValidator<GetEmpresaByNameQuery>
    {
        public GetEmpresaByNameValidator()
        {
            RuleFor(v => v.Name)
                .MinimumLength(3)
                .NotEmpty();
        }

    }
}
