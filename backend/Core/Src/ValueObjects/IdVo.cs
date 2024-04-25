namespace Stairways.Core.ValueObjects;

public abstract class Id 
{
  public string Value {get;set;}
  protected Id(string id)
  {
    Value = id;
  }
}