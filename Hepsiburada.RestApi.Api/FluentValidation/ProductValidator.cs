using FluentValidation;
using Hepsiburada.RestApi.DataAccess.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiburada.RestApi.Api.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Id).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Must(IsValidId).WithMessage(Messages.IdFormatError);
            RuleFor(product => product.Name).Cascade(CascadeMode.Stop).NotNull().WithMessage(Messages.ProductNameNull).NotEmpty().WithMessage(Messages.ProductNameEmpty);
            RuleFor(product => product.Price).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage(Messages.ProductPriceIsInvalid);
            RuleFor(product => product.Currency).Cascade(CascadeMode.Stop).NotNull().WithMessage(Messages.ProductCurrencyNull).NotEmpty().WithMessage(Messages.ProductCurrencyEmpty);
        }
        private bool IsValidId(string arg)
        {
            return String.IsNullOrEmpty(arg) || !ObjectId.TryParse(arg, out _);
        }
    }
}
