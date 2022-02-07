using FluentValidation;

namespace Application.Features.Brands.Commends.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("İsim alanını doldurunuz.");
            RuleFor(u => u.Name).MinimumLength(3);
        }
    }
}
