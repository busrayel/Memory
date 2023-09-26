using FluentValidation;
using Memory.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.DependencyResolves.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).MaximumLength(30);
        }
    }
}
