using Product.Domain.Entities.Base;
using Product.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public partial class Product : BaseEntity, IAggregateRoot
    {
        public Product(string name, string barCode, string categoryName, string description, bool weighted,
            ProductStatus status, DateTime createdAt, DateTime updatedAt, string updatedBy, string createdBy, int id = 0)
        {
            Id = id;
            Name = name;
            BarCode = barCode;
            CategoryName = categoryName;
            Description = description;
            Weighted = weighted;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
        }



        public string Name { get; private set; }
        public string CategoryName { get; private set; }
        public string BarCode { get; private set; }
        public string Description { get; private set; }
        public bool Weighted { get; private set; }
        public ProductStatus Status { get; private set; }


        public Product UpdateStatus(ProductStatus newStatus)
        {
            return new(Name, BarCode, BarCode, Description, Weighted, newStatus, CreatedAt, DateTime.Now, "Admin", CreatedBy, Id);


        }
    }
}
