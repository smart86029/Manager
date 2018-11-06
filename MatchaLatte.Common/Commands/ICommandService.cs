using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatchaLatte.Common.Commands
{
    public interface ICommandService
    {
        Task<TResult> ExecuteAsync<TResult>(ICommand command);
    }
}
