using FluentValidation;

namespace BlogApi.Application.DTOs.PostDtos.Validators;

public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(50)
            .WithMessage("Title cannot exceed 50 characters.")
            .MinimumLength(5)
            .WithMessage("Title must be at least 5 characters.");
        
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required.")
            .MaximumLength(1000)
            .WithMessage("Content cannot exceed 1000 characters.")
            .MinimumLength(20)
            .WithMessage("Content must be at least 20 characters.");
    }
}