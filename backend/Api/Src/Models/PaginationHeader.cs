namespace Stairways.Api.Models;

public class PaginationHeader
{
  public int CurrentPage {get;set;}
  public int PageSize {get;set;}
  public int ItemsPerPage {get;set;}
  public int TotalItems {get;set;}
  public int TotalPages {get;set;}

  public PaginationHeader(int currentPage, int pageSize, int itemsPerPage, int totalItems, int totalPages)
  {
    CurrentPage = currentPage;
    PageSize = pageSize;
    ItemsPerPage = itemsPerPage;
    TotalItems = totalItems;
    TotalPages = totalPages;
  }

}