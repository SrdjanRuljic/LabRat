using FluentValidation;

namespace Application.Products.Commands
{
    public class InsertProductCommandValidator : AbstractValidator<InsertProductCommand>
    {
        public InsertProductCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(v => v.SerialNumber)
                .NotEmpty()
                .WithMessage("SerialNumber is required.");
        }
    }
}