namespace Stairways.Core.ValueObjects;

public abstract class Id 
{
  public string Value {get; protected set;}
  protected Id(string id)
  {
    Value = id;
  }

  public override bool Equals(object? obj)
  {
    if (obj == null)
      return false;
      
    var id = (Id)obj;
    return id.Value == Value;   
  }

  public override int GetHashCode()
  {
    return Value.GetHashCode();
  }
}