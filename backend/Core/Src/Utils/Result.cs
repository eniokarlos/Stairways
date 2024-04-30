namespace Stairways.Core.Utils;

public class Result<T, E> where E : Exception
{ 
  private T? _data;
  public E? Error {get;set;}
  public bool IsFail { get; set; }

  private Result(T data)
  {
    _data = data;
    IsFail = false;
  }

  private Result(E error)
  {
    _data = default;
    Error = error;
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
    else throw Error!;
  }

  public static implicit operator Result<T,E>(T data) => new Result<T, E>(data);
  public static implicit operator Result<T,E>(E error) => new Result<T,E>(error);

}

public class Result<E> where E : Exception
{
  public E? Error {get; set;}
  public bool IsFail {get; set;}

  private Result()
  {
    IsFail = false;  
  }

  private Result(E error)
  {
    Error = error;
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
      throw Error!;
    }
    else
    {
      throw new Exception("cannot unwrap void Result");
    }
  }

  public static implicit operator Result<E>(E error) => new Result<E>(error);
}
