using TesteNameSpace;
namespace TesteNameSpace.Exceptions;

public static class Utilities
{
    public static void montarMenu(List<string> options) {
        options.Select((x, index) => new { Index = index, Option = x })
        .ToList()
        .ForEach(item => Console.WriteLine($"{item.Index}. {item.Option}"));
    }

    public static Product getProductByCode(string code, List<Product> products_list) {
        return products_list.Single(item => item.Code == code);
    }

    public static void getProductsBelowLimit(int limit, List<Product> products_list) 
    {
        products_list.Where(item => item.Amount < limit)
        .ToList()
        .ForEach(item => Console.WriteLine($"{products_list.IndexOf(item) + 1}. {item.Name} - {item.Amount} item(ns)"));
    }
    public static void getProductsMinMax(int min, int max, List<Product> products_list) {
        products_list.Where(item => item.Amount >= min && item.Amount <= max)
        .ToList()
        .ForEach(item => Console.WriteLine($"{products_list.IndexOf(item) + 1}. {item.Name} - {item.Amount} item(ns)"));
    }

    public static void getTotalAmountAll(List<Product> products_list) {
        
        var total_list = products_list.Select(item => item.Amount * item.Price);
        double total_sum = total_list.Sum();

        total_list.ToList().ForEach(item => Console.WriteLine($"{total_list.ToList().IndexOf(item) + 1}. {item} unidades monetárias."));
        Console.WriteLine($"Valor total do estoque: {total_sum}");
    }

    public static bool isExistingCode(string code, List<Product> products_list) {
        return products_list.Any(item => item.Code == code);
    }

    public static bool isAnyProduct(List<Product> products_list) {
        return products_list.Any();
    }
}