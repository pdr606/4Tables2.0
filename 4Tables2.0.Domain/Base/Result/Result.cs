namespace _4Tables2._0.Domain.Base.Result
{
    public class Result
    {
        private Result(int statusCode, string message, bool isOk)
        {
            StatusCode = statusCode;
            Message = message;
            IsOk = isOk;
        }

        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public bool IsOk { get; private set; }
        public object Data { get; private set; }

        public static Result Create(int statusCode, string message, bool isOk)
        {
            return new Result(statusCode, message, isOk);
        }

        public Result SetData(object data)
        {
            this.Data = data; return this;
        }
    }
}
