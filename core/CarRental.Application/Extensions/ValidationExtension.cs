using CarRental.Application.Exception;
using FluentValidation;

namespace CarRental.Application.Extensions
{
    public static class ValidationExtension
    {

        public static async Task ThrowIfValidationFailAsync<T>(this IValidator<T> validator, T instance)
        {
            var validationResult = await validator.ValidateAsync(instance);
            if (!validationResult.IsValid)
            {
                throw new CarRentalValidationException(validationResult.Errors);
            }
        }

        public static IRuleBuilderOptions<T, TProperty> CheckNull<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.WithMessage($" Data  is required");
        }
    }
}
