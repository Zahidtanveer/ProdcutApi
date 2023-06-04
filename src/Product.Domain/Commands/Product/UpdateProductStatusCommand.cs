using Product.Domain.Commands.Base;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Commands.Product
{
    public class UpdateProductStatusCommand : CommandBase
    {
        public ProductStatus Status { get; set; }
    }
}
