using FluentValidation;

namespace Chronos.App.DataContracts.RequestsOfWork
{
    public class RequestOfWorkBaseValidator : AbstractValidator<RequestOfWorkBase>
    {
        public RequestOfWorkBaseValidator()
        {
            RuleFor(entity => entity.Name)
                .NotEmpty();

            RuleFor(entity => entity.ProductId)
                .NotEmpty();
        }
    }
}
