using System.Net;

namespace Domain.BaseResponse;

public class GenericBaseResponse<T>
{
    public GenericBaseResponse()
    {
    }

    public GenericBaseResponse(bool status, int statusCode, string message)
    {
        Status = status;
        Message = message;
        StatusCode = statusCode;
    }

    public GenericBaseResponse(bool status, int statusCode, string message, T data)
    {
        Status = status;
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public bool Status { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public object Meta { get; set; }
    public T Data { get; set; }
}
