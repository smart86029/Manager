namespace Manager.App.Commands
{
    public class CommandResult<TResult> where TResult : class
    {
        public bool IsSuccess { get; private set; }
        public TResult Result { get; private set; }

        public CommandResult(bool isSuccess, TResult result)
        {
            IsSuccess = isSuccess;
            Result = result;
        }
    }
}