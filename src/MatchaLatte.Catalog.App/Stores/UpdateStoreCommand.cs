using System;
using System.Collections.Generic;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Catalog.App.Stores
{
    public class UpdateStoreCommand : ICommand<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoFileName { get; set; }

        public string Phone { get; set; }

        public AddressDto Address { get; set; }

        public string Remark { get; set; }

        public ICollection<ProductCategoryDto> ProductCategories { get; set; } = new List<ProductCategoryDto>();
    }
}