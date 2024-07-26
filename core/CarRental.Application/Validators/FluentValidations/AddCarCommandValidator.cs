using CarRental.Application.Extensions;
using CarRental.Application.Features.Command;
using FluentValidation;

namespace CarRental.Application.Validators.FluentValidations
{
    public class AddCarCommandValidator : AbstractValidator<AddCarCommand>
    {
        public AddCarCommandValidator()
        {
            RuleFor(x => x.CarName)
                 .NotEmpty()
                 .CheckNull();

            RuleFor(x => x.Price)
                 .GreaterThan(1000)
                 .WithMessage("Price must greater than 1000");

            RuleFor(x => x.Model)
                    .NotEmpty()
                    .CheckNull();

        }
    }
}
