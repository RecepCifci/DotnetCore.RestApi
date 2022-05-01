using FluentValidation;
using DotnetCore.RestApi.DataAccess.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.Api.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Id).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Must(IsValidId).WithMessage(Messages.IdFormatError);
            RuleFor(category => category.Name).Cascade(CascadeMode.Stop).NotNull().WithMessage(Messages.CategoryNameNull).NotEmpty().WithMessage(Messages.CategoryNameEmpty);
        }
        private bool IsValidId(string arg)
        {
            return String.IsNullOrEmpty(arg) || !ObjectId.TryParse(arg, out _);
        }
    }
}
