using FluentValidation;
using JwtAuthExample.Core.Entities;

namespace JwtAuthExample.WebAPI.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty();
            RuleFor(i => i.Price)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}