using FluentValidation;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Commands.Product.Validators
{
    public class SellProductCommandValidator : ProductCommandValidatorBase<SellProductCommand>
    {
        public SellProductCommandValidator(IProductRepository productRepository) : base(productRepository)
        {
            
        }

       
    }
}
