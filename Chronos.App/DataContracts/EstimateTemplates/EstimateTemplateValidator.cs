using FluentValidation;
using FluentValidation.Validators;

namespace Chronos.App.DataContracts.EstimateTemplates
{
    public class EstimateTemplateValidator : AbstractValidator<EstimateTemplate>
    {
        public EstimateTemplateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.GeneralValues)
                .ForEach(generalValueRule =>
                {
                    generalValueRule.Must(y => !string.IsNullOrEmpty(y.Name)); 
                    generalValueRule.Must(y => !string.IsNullOrEmpty(y.Value)); 
                });






        }

        public class NamesInGeneralValuesShouldBeUnique<T> : PropertyValidator<EstimateTemplate, string>
        {

        }
    }

    
}
