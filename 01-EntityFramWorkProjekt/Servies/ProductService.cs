

using _01_EntityFramWorkProjekt.Contexts;
using _01_EntityFramWorkProjekt.Forms;
using _01_EntityFramWorkProjekt.Migrations;
using _01_EntityFramWorkProjekt.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFramWorkProjekt.Servies;

    internal class ProductService
    {

    private readonly DataContext _context = new DataContext();
    private readonly CategoryService _categoryService = new CategoryService();
    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.Include(x => x.Category).ToListAsync();
    }
    public async Task<ProductEntity> GetAsync (string articleNumber)
    {
        var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        if (productEntity != null)
            return productEntity;
        return null!;
    }

    public async Task DeleteAsync(string articleNumber)
    {
        var productEntity = await _context.Products.FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        if (productEntity != null)
        {
            _context.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<ProductEntity> CreateAsync (ProductForm form)
    {
        if (await _context.Products.AnyAsync(x => x.ArticleNumber == form.ArticleNumber))
            return null!;

        var producEntity = new ProductEntity()
        {
            ArticleNumber = form.ArticleNumber,
            Name = form.Name,
            Description = form.Description,
            StockPrice = form.StockPrice,
       CategoryId = (await _categoryService.GetOrCreateIfNotExists(form.CategoryName)).Id

        };
        _context.Add(producEntity);
        await _context.SaveChangesAsync();
        return producEntity;
    }
    }

