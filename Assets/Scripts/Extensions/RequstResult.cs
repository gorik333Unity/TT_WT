using System;

namespace Extensions
{
    public class RequstResult<TData>
    {
        public TData Data { get; }
        public Exception Exception { get; }
        public bool IsSuccesful => Exception == null;

        public RequstResult(TData data)
        {
            Data = data;
        }

        public RequstResult(Exception exception)
        {
            Exception = exception;
        }
    }
}