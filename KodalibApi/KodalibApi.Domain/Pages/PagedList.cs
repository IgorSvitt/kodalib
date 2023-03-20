using Microsoft.EntityFrameworkCore;

namespace GenelogyApi.Domain.ViewModels.Pages;

public class PagedList<T>
{
    private List<T> items = new List<T>();
    public List<T> Items => items;
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        this.items.AddRange(items);
    }

    public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var count = source.Count();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}