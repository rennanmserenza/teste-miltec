using System.Text.Json.Serialization;

namespace ProjetoAnunciosMilTec.Core.Responses;

public class PagedResponse<TData> : BaseResponse<TData>
{
    [JsonConstructor]
    public PagedResponse(TData? data,
        int totalCount, int currentPage = Configuration.DefaultCurrentPage, int pageSize = Configuration.DefaultPageSize)
        : base(data)
    {
        Data = data;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public PagedResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        : base(data, code, message)
    {
    }

    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}