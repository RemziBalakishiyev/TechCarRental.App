using FluentValidation.Results;

namespace CarRental.Application.Exception;

public class CarRentalValidationException : ApplicationException
{
    public List<ValidationFailure> ValidationFailures { get; set; }
    public CarRentalValidationException(List<ValidationFailure> validationFailures)
        :base("Validation Exception")
    {
        ValidationFailures = validationFailures;
    }
}
