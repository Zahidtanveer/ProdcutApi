﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Commands.Base
{
    public abstract class CommandHandlerBase
    {
        protected IEnumerable<string> Notifications;

        protected ValidationResult Validate<T, TValidator>(
            T command,
            TValidator validator)
            where T : CommandBase
            where TValidator : IValidator<T>
        {
            var validationResult = validator.Validate(command);
            Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            return validationResult;
        }

        public Result Return() => new Result(!Notifications.Any(), Notifications);
    }
}
