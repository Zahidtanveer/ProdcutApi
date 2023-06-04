using Product.Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Interfaces
{
    public interface ICommandHandler<in T> where T : CommandBase
    {
        Task<Result> Handle(T command);
    }
}
