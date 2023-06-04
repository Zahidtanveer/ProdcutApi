using FluentValidation;
using Product.Domain.Commands.Base;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Commands.Product.Validators
{
    public abstract class ProductCommandValidatorBase<T> : AbstractValidator<T> where T : CommandBase
    {
        private readonly IProductRepository _productRepository;

        protected ProductCommandValidatorBase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            ValidateId();
        }
        private void ValidateId()
        {
            RuleFor(productRepository => productRepository.Id)
                .Must(id => !string.IsNullOrEmpty(id.ToString()))
                .WithSeverity(Severity.Error)
                .WithMessage("Id can't be empty");
        }

    }
}
