namespace Test.Responses
{
    public class ApiSuccessResponse<T>
    {
        public bool Success { get; set; } = true;    // always true for success
        public string? Message { get; set; } = null;
        public T? Data { get; set; } = default;

        public ApiSuccessResponse() { }

        public ApiSuccessResponse(T? data = default, string? message = null)
        {
            Data = data;
            Message = message;
        }
    }
    
}
