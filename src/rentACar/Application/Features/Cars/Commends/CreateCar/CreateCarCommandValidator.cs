using Application.Constants;
using Application.Features.Cars.Validations;
using FluentValidation;

namespace Application.Features.Cars.Commends.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.ModelYear).GreaterThan((short)1980);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.CityId).NotEmpty();
            RuleFor(c => c.Plate)
                .NotEmpty()
                .Must(CarCustomValidationRules.IsTurkeyPlate)
                .WithMessage(Message.PlateNotValid);
        }
    }
}
