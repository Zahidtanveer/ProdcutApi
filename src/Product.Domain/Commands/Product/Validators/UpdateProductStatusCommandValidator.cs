using FluentValidation;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Commands.Product.Validators
{
    public class UpdateProductStatusCommandValidator : ProductCommandValidatorBase<UpdateProductStatusCommand>
    {
        public UpdateProductStatusCommandValidator(IProductRepository productRepository) : base(productRepository)
        {
            ValidateStatus();
        }

        private void ValidateStatus()
        {
            RuleFor(productRepository => productRepository.Status)
                .Must(status => !string.IsNullOrEmpty(status.ToString()))
                .WithSeverity(Severity.Error)
                .WithMessage("Status can't be empty");
        }
    }
}
