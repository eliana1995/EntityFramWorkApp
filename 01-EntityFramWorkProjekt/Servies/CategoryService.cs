

using _01_EntityFramWorkProjekt.Contexts;
using _01_EntityFramWorkProjekt.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFramWorkProjekt.Servies;

    internal class CategoryService
  {

    private readonly DataContext _context = new DataContext();

    public async Task<CategoryEntity> GetOrCreateIfNotExists(string categoryName)
    {
        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
        if (categoryEntity == null)
        {
            categoryEntity = new CategoryEntity() { Name = categoryName };
            _context.Add(categoryEntity);
            await _context.SaveChangesAsync();
        }

        return categoryEntity;
    }

    public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task DeleteAsync (string categoryName)
    {
        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
        if (categoryEntity != null)
        {
            _context.Remove(categoryEntity);
            await _context.SaveChangesAsync();
        }
    }


  }

