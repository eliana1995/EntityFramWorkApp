
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_EntityFramWorkProjekt.Models.Entites;

    internal class ProductEntity
    {

    [Key]
    public string ArticleNumber { get; set; } = null!;

    [Required]
    [Column(TypeName ="nvarchar(200)")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; } 

    [Required]
    [Column(TypeName = "money")]
    public decimal StockPrice { get; set;  }

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

    }




