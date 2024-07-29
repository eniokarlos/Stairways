namespace Stairways.Core.Utils;

public class PagedList<T> : List<T>
{
  public int CurrentPage {get;set;}
  public int TotalPages {get;set;}
  public int ItemsPerPage {get;set;}
  public int TotalCount {get;set;}


  /// <param name="items">lista dos items de entrada</param>
  /// <param name="currentPage">numero atual da pagina</param>
  /// <param name="itemsPerPage">numero maximo de items por pagina</param>
  /// <param name="totalCount">numero total de items</param>
  public PagedList(IEnumerable<T> items, int currentPage, int itemsPerPage, int totalCount)
  {
    CurrentPage = currentPage;
    TotalCount = totalCount;
    ItemsPerPage = itemsPerPage;
    TotalPages = (int) Math.Ceiling(Count / (double) itemsPerPage);
    AddRange(items);
  }

  /// <param name="items">lista dos items de entrada</param>
  /// <param name="currentPage">numero atual da pagina</param>
  /// <param name="itemsPerPage">numero maximo de items por pagina</param>
  /// <param name="totalCount">numero total de items</param>
  /// <param name="totalPages">numero total de paginas</param>
  public PagedList(IEnumerable<T> items, int currentPage, int itemsPerPage, int totalCount, int totalPages)
  {
    CurrentPage = currentPage;
    TotalCount = totalCount;
    ItemsPerPage = itemsPerPage;
    TotalPages = totalPages;
    AddRange(items);
  }
}