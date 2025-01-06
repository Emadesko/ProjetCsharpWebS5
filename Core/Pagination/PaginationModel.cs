using Microsoft.EntityFrameworkCore;

namespace ProjetCsharpWebS5.Core.Pagination;

public class PaginationModel<T>
{
    public List<T> Items { get; set; }
    public Pagination Pagination { get; set; }
    protected PaginationModel(List<T> items, int totalItems, int pageSize, int currentPage)
    {
        Items = items;
        Pagination = new Pagination(totalItems, pageSize, currentPage);
    }

    public static async Task<PaginationModel<T>> Paginate(IQueryable<T> data, int pageSize, int currentPage)
    {
        var elements = await data.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        var count = await data.CountAsync();
        return new PaginationModel<T>(elements, count, pageSize, currentPage);
    }

}