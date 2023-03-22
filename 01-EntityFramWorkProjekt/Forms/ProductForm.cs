

namespace _01_EntityFramWorkProjekt.Forms;

    internal class ProductForm
    {
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public decimal StockPrice { get; set; }

    public string CategoryName { get; set; } = null!;
}

