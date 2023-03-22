

using _01_EntityFramWorkProjekt.Forms;

namespace _01_EntityFramWorkProjekt.Servies;

internal class MenuService
{
    private readonly ProductService _productService = new ProductService();
    public async Task MainMenu()
    {
        Console.Clear();
        Console.WriteLine("####### HUVUDMENY #######");
        Console.WriteLine("1. Skapa en product");
        Console.WriteLine("2. Visa alla Product");
        Console.WriteLine("3.Visa specifik produckt");
        Console.Write("\nange ett av följande alternativ (1-3):");

        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
               await CreateMenu();

                break;

            case "2":
               await ShowAllMenu();
                break;

            case "3":
              await  ShowSpecificMenu();
                break;
        }

        Console.ReadKey();
    }
    public async Task CreateMenu ()
    
    {
        var form = new ProductForm();
        Console.Clear();
        Console.WriteLine("####### Skapa product #######");
        Console.Write("Artikelnummer:"); form.ArticleNumber = Console.ReadLine() ?? "";
        Console.Write("productnamn:"); form.Name = Console.ReadLine() ?? "";
        Console.Write("productcategory:"); form.CategoryName = Console.ReadLine() ?? "";
        Console.Write("productprice:"); form.StockPrice = decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("productdescription:"); form.Description = Console.ReadLine() ?? "";

        Console.WriteLine();
        var result = await _productService.CreateAsync(form);
        if (result == null)
            Console.WriteLine("det finns redan en product");
        else
            Console.WriteLine($"product with artikelnumer {result.ArticleNumber} is created.");
    }
    public async Task ShowAllMenu() 
    {

        Console.Clear();
        Console.WriteLine("#######  PRODUCT #######");
        foreach (var product in await _productService.GetAllAsync())
            Console.WriteLine($"{product.ArticleNumber},{product.Name},{product.StockPrice}SEK ");
    }
    public async Task ShowSpecificMenu()
    {
        await ShowAllMenu();
        Console.Write("Ange Artikelnummer:");
        var articleNumber = Console.ReadLine();

        if (!string.IsNullOrEmpty(articleNumber))
        {
            var product = await _productService.GetAsync(articleNumber);
            if (product != null)
            {

                Console.Clear();
                Console.WriteLine("####### information #######");
                Console.WriteLine($"Artikelnummer: {product.ArticleNumber}");
                Console.WriteLine($"nummer : {product.Name}");
                Console.WriteLine($"pris : {product.StockPrice}");
                Console.WriteLine($"category : {product.Category.Name}");

                Console.WriteLine($"description : {product.Description}");
            }

            else
            {
                Console.WriteLine($" no articl with articl number {articleNumber} customer is found .");
            }
        }

        else
        {
            Console.WriteLine("no article number");
        }
    }
}

