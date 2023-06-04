using Product.Infrastructure.Repositories.Base;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Domain.Entities.Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
