using Microsoft.EntityFrameworkCore;

namespace ProjetCsharpWebS5.Core.Pagination;

public class Pagination
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    public Pagination(int totalItems, int pageSize, int currentPage)
    {
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        TotalItems = totalItems;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
}