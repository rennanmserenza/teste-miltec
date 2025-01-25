namespace ProjetoAnunciosMilTec.Core.Request;

public abstract class PagedRequest
{
    public int PageNumber { get; set; } = Configuration.DefaultCurrentPage;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int Skip => PageNumber <= 0 ? PageNumber * PageSize : (PageNumber - 1) * PageSize;
}