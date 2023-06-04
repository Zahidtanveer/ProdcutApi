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
    public class UpdateProductStatusCommandHandler : CommandHandlerBase, ICommandHandler<UpdateProductStatusCommand>
    {

        private readonly IValidator<UpdateProductStatusCommand> _updateProductStatusCommandValidator;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductStatusCommandHandler(IValidator<UpdateProductStatusCommand> validator, IUnitOfWork unitOfWork)
        {
            _updateProductStatusCommandValidator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateProductStatusCommand command)
        {
            var validationResult = Validate(command, _updateProductStatusCommandValidator);
            List<string> messages = new();
            // Update Status Of Product
            if (validationResult.IsValid)
            {
                // Retrieve the product from the database
                var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetAsync(p => p.Id == command.Id);

                if (product != null)
                {
                    // Update Product Status
                    var updatedProduct = product.UpdateStatus(command.Status);

                    // Update Status in Db
                    await _unitOfWork.Repository<Domain.Entities.Product>().UpdateAsync(updatedProduct);
                    await _unitOfWork.SaveChangesAsync();

                    // Send Success Message as Result
                    messages.Add("Success! Product Status Successfully Updated!");
                    return new Result(true, messages);
                }

                // Send Error Message as Result Not Found
                messages.Add("Error! No Product Found!");
                return new Result(false, messages);
            }

            return Return();
        }
    }
}

