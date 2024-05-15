using Stairways.Core.Errors;
using Stairways.Core.Utils;

namespace Stairways.Core.Interfaces;

public interface IValidatable
{
  Result<EntityValidationException> Validate();
}