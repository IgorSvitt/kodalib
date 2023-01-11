using KodalibApi.Data.Responce.Enum;

namespace KodalibApi.Data.Responce;

public class BaseResponce<T>: IBaseResponce<T>
{
    // Description of responce
    public string Description { get; set; }

    // Status code of responce
    public StatusCode StatusCode { get; set; }

    // Data of responce
    public T Data { get; set; }
}

public interface IBaseResponce<T>
{
    T Data { get; }
    StatusCode StatusCode { get; set; }
}