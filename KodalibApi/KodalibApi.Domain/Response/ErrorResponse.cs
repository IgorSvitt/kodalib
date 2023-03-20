using KodalibApi.Data.Response.Enum;

namespace KodalibApi.Data.Response;

public class ErrorResponse: IErrorResponse
{
    // Description of response
    public string? Description { get; set; }

    // Status code of response
    public StatusCode StatusCode { get; set; }
}