namespace ContosoClothing.Api.Models;

public sealed class ApiError
{
    public string Message { get; init; } = string.Empty;

    public static ApiError Create(string message) => new()
    {
        Message = message
    };
}
