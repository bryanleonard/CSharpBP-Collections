namespace Acme.Common
{
    public class OperationResult<T>
    {
        public OperationResult()
        {
        }

        public OperationResult(T result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }

        public T Result { get; set; }
        public string Message { get; set; }
    }


    /// <summary>
    /// Provides a success flag and message 
    /// useful as a method return type.
    /// </summary>
    public class OperationResultOriginal
    {
        public OperationResultOriginal()
        {
        }

        public OperationResultOriginal(bool success, string message) : this()
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class OperationResultDecimal
    {
        public OperationResultDecimal()
        {

        }

        public OperationResultDecimal(decimal result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }

        public decimal Result { get; set; }
        public string Message { get; set; }
    }

}
