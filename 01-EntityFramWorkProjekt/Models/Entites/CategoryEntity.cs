

namespace _01_EntityFramWorkProjekt.Models.Entites;

internal class CategoryEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();


}