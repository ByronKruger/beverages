namespace Coffeeg.Helpers
{
    public record Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string ErrorMessage { get; set; }

        public static Result<T> Success(T value) => new()
        { IsSuccess = true, Value = value };

        public static Result<T> Failure(string? message = null) => new()
        { IsSuccess = false, ErrorMessage = message };
    }
}
