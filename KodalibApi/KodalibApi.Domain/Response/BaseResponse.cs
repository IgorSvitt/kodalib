using KodalibApi.Data.Response.Enum;

namespace KodalibApi.Data.Response;

public class BaseResponse<T>: IOkResponse<T>
{
    // Description of responce
    public string Description { get; set; }

    // Status code of responce
    public StatusCode StatusCode { get; set; }

    // Data of responce
    public T Data { get; set; }
}

public interface IBaseResponse
{
    string Description { get; }
    StatusCode StatusCode { get; set; }
}

public interface IOkResponse<T>: IBaseResponse
{
    T Data { get; }
}

public interface IErrorResponse: IBaseResponse{}