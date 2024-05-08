namespace _4Tables2._0.Domain.Base.Common
{
    public class BasicResult
    {
        public bool IsSucces { get; }
        public bool IsFailure => !IsSucces;
        public Error Error { get;}

        protected BasicResult(bool isSucces, Error error)
        {
            IsSucces = isSucces;
            Error = error;
        }

        public static BasicResult Success() => new(true, Error.None);

        public static BasicResult<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

        public static BasicResult Failure(Error error) => new(false, error);

        public static BasicResult<TValue> Failure<TValue>(Error error) => new(default, false, error);

        protected static BasicResult<TValue> Create<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.None);


    }
}
