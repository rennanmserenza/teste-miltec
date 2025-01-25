using System.Text.Json.Serialization;

namespace ProjetoAnunciosMilTec.Core.Responses;

public class BaseResponse<TData>
{
    private readonly int _statusCode;

    [JsonConstructor]
    public BaseResponse() =>
        _statusCode = Configuration.DefaultStatusCode;

    public BaseResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        _statusCode = code;
        Data = data;
        Message = message;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess
        => _statusCode >= 200 && _statusCode <= 299;
}