using FluentValidation;
using Product.Domain.Commands.Base;
using Product.Domain.Commands.Product;
using Product.Domain.Entities;
using Product.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Services.Product.CommandHandler
{
    public class SellProductCommandHandler : CommandHandlerBase, ICommandHandler<SellProductCommand>
    {
        private readonly IValidator<SellProductCommand> _createProductCommandValidator;
        private readonly IUnitOfWork _unitOfWork;

        public SellProductCommandHandler(IValidator<SellProductCommand> validator, IUnitOfWork unitOfWork)
        {
            _createProductCommandValidator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SellProductCommand command)
        {
            var validationResult = Validate(command, _createProductCommandValidator);
            List<string> messages = new();
            if (validationResult.IsValid)
            {
                // Sell Product
                if (validationResult.IsValid)
                {
                    // Retrieve the product from the database check available InStock
                    var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetAsync(p => p.Id == command.Id && p.Status == ProductStatus.InStock);

                    if (product != null)
                    {
                        var updatedProduct = product.UpdateStatus(ProductStatus.Sold);

                        // Change Product form InStock to Sold In DB
                        await _unitOfWork.Repository<Domain.Entities.Product>().UpdateAsync(updatedProduct);
                        await _unitOfWork.SaveChangesAsync();

                        // Send Success Message as Result
                        messages.Add("Success! Product Sold Successfully Updated!");
                        return new Result(true, messages);
                    }

                    // Send Error Message as Result Not Found
                    messages.Add("Error! No Product InStock with this Id avaialble for Sell!");
                    return new Result(false, messages);
                }

            }

            return Return();
        }
    }
}

