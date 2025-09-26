namespace Test.Responses
{
    public class ApiErrorResponse
    {
        public bool Success { get; set; } = false;
        public string Error { get; set; } = string.Empty;
        public List<string>? MissingFields { get; set; } = null;

        public ApiErrorResponse() { }

        public ApiErrorResponse(string error, List<string>? missingFields = null)
        {
            Error = error;
            MissingFields = missingFields;
        }
    }
}
