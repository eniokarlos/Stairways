namespace Stairways.Core.Utils;

public static class ResultListConverter
{
  public static Result<ICollection<R>, E> ToResultList<T,E,R>(this ICollection<T> values, 
    Func<T, Result<R,E>> action) where E: Exception
  {
    var resultList = new List<R>();

    foreach (var value in values)
    {
      var actionResult = action(value);

      if (actionResult.IsFail)
        return Result<ICollection<R>, E>.Fail(actionResult.Error!);
      
      resultList.Add(actionResult.Unwrap());
    }
    return Result<ICollection<R>, E>.Ok(resultList);
  }
}