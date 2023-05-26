using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LessonValidator:AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(l => l.LessonName).NotEmpty();
            RuleFor(l => l.PeriodId).GreaterThan(0);
            RuleFor(l => l.LessonName).MinimumLength(5);
        }
    }
}
