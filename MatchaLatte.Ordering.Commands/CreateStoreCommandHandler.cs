using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Store;
using MatchaLatte.Ordering.App.ViewModels;

namespace MatchaLatte.Ordering.Commands
{
    public class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand, StoreDetail>
    {
        public Task<StoreDetail> HandleAsync(CreateStoreCommand command)
        {
            throw new NotImplementedException();
        }
    }
}