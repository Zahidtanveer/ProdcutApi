using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Commands.Base
{
    public class Result
    {
        public readonly IEnumerable<string> Messages;
        public readonly bool Success;

        public Result(bool success, IEnumerable<string> messages)
        {
            Success = success;
            Messages = messages;
        }
    }
}
