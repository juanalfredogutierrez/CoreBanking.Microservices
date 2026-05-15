namespace SharedKernel.Result
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }

        public bool IsFailure => !IsSuccess;

        public string Error { get; protected set; } = string.Empty;

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success()
            => new(true, string.Empty);

        public static Result Failure(string error)
            => new(false, error);
    }
}
