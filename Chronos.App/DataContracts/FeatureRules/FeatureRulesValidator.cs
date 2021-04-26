using FluentValidation;

namespace Chronos.App.DataContracts.FeatureRules
{
    public class FeatureRulesValidator : AbstractValidator<FeatureRules>
    {
        public FeatureRulesValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
