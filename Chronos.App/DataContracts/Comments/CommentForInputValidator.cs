using FluentValidation;

namespace Chronos.App.DataContracts.Comments
{
    public class CommentForInputValidator : AbstractValidator<CommentForInput>
    {
        public CommentForInputValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty();
        }
    }
}
