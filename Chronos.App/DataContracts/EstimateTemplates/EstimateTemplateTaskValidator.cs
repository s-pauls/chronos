using FluentValidation;

namespace Chronos.App.DataContracts.EstimateTemplates
{
    public class EstimateTemplateTaskValidator : AbstractValidator<EstimateTemplateTask>
    {
        public EstimateTemplateTaskValidator()
        {
            RuleFor(x => x.TaskName)
                .NotEmpty();

            RuleFor(x => x.Activity)
                .NotEmpty();

            RuleFor(x => x.TaskLevel)
                .NotEmpty();
        }
    }
}
