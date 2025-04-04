using System;
using Application.Activities.DTOs;
using FluentValidation;

namespace Application.Activities.Validators;

public class BaseActivityValidator<T, TDto> : AbstractValidator<T> where TDto : BaseActivityDto
{
    public BaseActivityValidator(Func<T, TDto> selector)
    {
        RuleFor(x => selector(x).Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters");
        RuleFor(x => selector(x).Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(300).WithMessage("Description must not exceed 300 characters");
        RuleFor(x => selector(x).Date)
            .GreaterThan(DateTime.Now).WithMessage("Date must be in the future");
        RuleFor(x => selector(x).Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(50).WithMessage("Category must not exceed 50 characters");
        RuleFor(x => selector(x).Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(50).WithMessage("Category must not exceed 50 characters");
        RuleFor(x => selector(x).City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(50).WithMessage("Category must not exceed 50 characters");
        RuleFor(x => selector(x).Latitude)
            .NotEmpty().WithMessage("Latitude is required")
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90");
        RuleFor(x => selector(x).Longitude)
            .NotEmpty().WithMessage("Longitude is required")
            .InclusiveBetween(-180, 180).WithMessage("Longitude  must be between -180 and 180");
    }
}