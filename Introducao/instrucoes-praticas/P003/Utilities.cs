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
        .ForEach(item => Console.WriteLine($"{products_list.IndexOf(item)}. {item.Name} - {item.Amount} item(ns)"));
    }
    public static void getProductsMinMax(int min, int max, List<Product> products_list) {
        products_list.Where(item => item.Amount >= min && item.Amount <= max);
        
        //.ForEach(item => Console.WriteLine($"{products_list.IndexOf(item)}. {item.Name} - {item.Amount} item(ns)"));
    }

    public static void getTotalAmountAll(List<Product> products_list) {
        //List<Product> total_list = products_list.Select(item => item.Amount * item.Price);
        foreach (var ola in products_list.Select(item => item.Amount * item.Price)) {
            Console.WriteLine($"{ola}");
            
        }
        double sum_total = 12.5;//total_list.Sum();

        //products_list.ForEach(item => Console.WriteLine($"Valor total de {item.Name} - {total_list[products_list.IndexOf(item)]} unidades monetárias"));
        Console.WriteLine($@"Valor total do estoque: {sum_total}");
    }
}