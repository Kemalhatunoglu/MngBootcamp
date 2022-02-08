using FluentValidation;

namespace Application.Features.FindeksCredits.Command.CreateFindeksCredit
{
    public class CreateFindeksCreditCommandValidator : AbstractValidator<CreateFindeksCreditCommand>
    {
        public CreateFindeksCreditCommandValidator()
        {
            RuleFor(f => f.Score).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1900);
        }
    }
}
