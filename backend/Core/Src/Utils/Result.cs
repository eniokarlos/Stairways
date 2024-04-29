namespace Stairways.Core.Utils;

public class Result<T, E> where E : Exception
{ 
  private T? _data;
  private E? _error;
  public bool IsFail { get; set; }

  private Result(T data)
  {
    _data = data;
    _error = null;
    IsFail = false;
  }

  private Result(E error)
  {
    _data = default;
    _error = error;
    IsFail = true;
  }

  public static Result<T,E> Ok(T data)
  {
    return new Result<T, E>(data);
  }

  public static Result<T,E> Fail(E error)
  {
    return new Result<T, E>(error);
  }

  public T Unwrap()
  {
    if (!IsFail)
      return _data!;
    else throw _error!;
  }

  public static implicit operator Result<T,E>(T data) => new Result<T, E>(data);
  public static implicit operator Result<T,E>(E error) => new Result<T,E>(error);

}

public class Result<E> where E : Exception
{
  private E? _error;
  public bool IsFail {get; set;}

  private Result()
  {
    IsFail = false;  
  }

  private Result(E error)
  {
    _error = error;
    IsFail = true;
  }

  public static Result<E> Ok()
  {
    return new Result<E>();
  }

  public static Result<E> Fail(E error)
  {
    return new Result<E>(error);
  }

  public void Unwrap()
  {
    if (IsFail)
    {
      throw _error!;
    }
    else
    {
      throw new Exception("cannot unwrap void Result");
    }
  }

  public static implicit operator Result<E>(E error) => new Result<E>(error);
}
