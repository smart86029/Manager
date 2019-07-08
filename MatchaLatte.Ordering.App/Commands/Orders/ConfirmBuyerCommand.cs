using System;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.App.Commands.Orders
{
    public class ConfirmBuyerCommand : ICommand<bool>
    {
        public Guid Id { get; set; }
    }
}