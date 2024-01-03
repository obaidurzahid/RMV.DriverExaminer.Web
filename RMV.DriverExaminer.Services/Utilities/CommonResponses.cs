namespace RMV.DriverExaminer.Services.Utilities
{
    public class Response
    {
        public string? ReturnCode { get; set; }
        public int? ReturnCodeInt { get; set; }
        public long? ReturnCodeLong { get; set; }
        public required bool IsSuccess { get; set; }
        public required string Message { get; set; }
    }
    public class NameId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class TextValue
    {
        public required string Value { get; set; }
        public required string Text { get; set; }
    }


    public class NameValue
    {
        public required string Name { get; set; }
        public decimal? Value { get; set; }
    }
    public class Error
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(int statusCode, string message, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
    }
}
