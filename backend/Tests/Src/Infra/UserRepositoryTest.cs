using Microsoft.EntityFrameworkCore;
using Stairways.Infra.Context;
using Stairways.Infra.Repositories;

namespace Stairways.Tests.Infra;

public class UserRepositoryTest
{
  
  [Fact (Skip = "skipped test")]
  public async void Tests()
  {
    var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
    builder.UseInMemoryDatabase("inMemoryDb");

    var context = new ApplicationDbContext(builder.Options);

    var repository = new UserRepository(context);

    var user = await repository.GetByIdAsync("4be48976-117a-42fc-9888-846d57ee14b2");

    Assert.NotNull(user.Unwrap());
  }
}