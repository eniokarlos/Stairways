using System.ComponentModel.DataAnnotations;

namespace Stairways.Api.Models;

public class PaginationParams
{
  public int PageNumber {get;set;}

  [Range(1, 20, ErrorMessage = "Max number of items per page is 20")]
  public int PageSize {get;set;}
}