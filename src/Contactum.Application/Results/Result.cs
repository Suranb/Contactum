namespace Contactum.Application.Results
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public string? Error { get; }
        public ErrorType ErrorType { get; }

        private Result(bool isSuccess, T? value, string? error, ErrorType errorType)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
            ErrorType = errorType;
        }

        public static Result<T> Success(T value)
            => new(true, value, null, ErrorType.None);
        
        public static Result<T> Failure(string error, ErrorType errorType = ErrorType.Failure)
            => new(false, default, error, errorType);

        public static Result<T> NotFound(string error = "Resource not found")
            => new(false, default, error, ErrorType.NotFound);

        public static Result<T> ValidationError(string error) =>
            new(false, default, error, ErrorType.Validation);
    }

    public enum ErrorType
    {
        None,
        Failure,        // Generic business logic failure
        NotFound,       // Entity not found
        Validation,     // Validation error
        Unauthorized,   // Auth error
        Forbidden       // Permission error
    }
}
