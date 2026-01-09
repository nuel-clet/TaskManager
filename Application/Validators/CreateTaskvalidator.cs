using Application.DTOs.Tasks;
using FluentValidation;

namespace Application.Validators
{
    public class CreateTaskvalidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskvalidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.ProjectId)
                .NotEmpty();
        }
    }
}
