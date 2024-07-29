using Microsoft.EntityFrameworkCore;
using Stairways.Core.Interfaces;
using Stairways.Core.Models;
using Stairways.Infra.Context;

namespace Stairways.Infra.Repositories;

public class CategoryRepository : ICategoryRepository
{
  private readonly ApplicationDbContext _context;

  public CategoryRepository(ApplicationDbContext context) 
  {
    _context = context;
  }

  public async Task<ICollection<CategoryEntity>> GetCategories()
  {
    return await _context.Categories.ToListAsync();
  }
}