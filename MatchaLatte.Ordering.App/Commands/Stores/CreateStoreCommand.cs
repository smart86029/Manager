using System.Collections.Generic;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Queries.Stores;

namespace MatchaLatte.Ordering.App.Commands.Stores
{
    public class CreateStoreCommand : ICommand<StoreDetail>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public AddressDto Address { get; set; }
        public string Remark { get; set; }
        public ICollection<ProductCategoryDto> ProductCategories { get; set; } = new List<ProductCategoryDto>();
    }
}