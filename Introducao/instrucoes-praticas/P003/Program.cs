using TesteNameSpace;
using TesteNameSpace.Exceptions;

List<string> menu_options = new List<string>();
bool flag = false;
string code, name;
double price;
int user_option = 0,
    amount,
    min_amount,
    max_amount,
    product_index;
Product product = new Product();
List<Product> products_list = new List<Product>();

do {
    menu_options = new string[] {
        "Sair do programa",
        "Cadastrar produto",
        "Consultar produtos",
        "Atualizar estoque",
        "Gerar relatórios"
    }.ToList();
    Utilities.montarMenu(menu_options);
    Console.Write("\nSua opção: ");
    user_option = int.Parse(Console.ReadLine());

    try {
        Console.WriteLine($"\nOPÇÃO {menu_options[user_option].ToUpper()}\n");
    } catch {}
    
    switch (user_option)
    {
        case 0:
            Console.WriteLine($"Fim do programa, volte sempre!");
            break;
            
        case 1: // Cadastro de produto
            do {
                Console.Write($"Informe o código: ");
                code = Console.ReadLine();
                flag = false;

                if ( Utilities.isExistingCode(code, products_list) ) {
                    Console.WriteLine("Este código já existe, entre com um diferente!");
                    
                    flag = true;
                }
            } while (flag);
            

            // try {
            //     product.setName(code);
            // } 
            // catch (ArgumentNullException ex) {
            //     Console.WriteLine(ex.Message);
            // }

            Console.Write($"Informe o nome: ");
            name = Console.ReadLine();

            Console.Write($"Informe a quantidade: ");
            amount = int.Parse(Console.ReadLine());

            Console.Write($"Informe o preço: ");
            price = double.Parse(Console.ReadLine());

            product.Name = name;
            product.Amount = amount;
            product.Price = price;
            product.Code = code;

            products_list.Add(product);

            Console.WriteLine($"\nEste produto foi cadastrado com sucesso!");
            break;

        case 2: // Consulta de produto
            Console.Write($"Informe o código: ");
            code = Console.ReadLine();

            try {
                product = Utilities.getProductByCode(code, products_list);

                Console.WriteLine($@"DADOS DO PRODUTO
                Código: {product.Code}
                Nome: {product.Name}
                Quantidade: {product.Amount}
                Preço: {product.Price}");
            } catch (InvalidOperationException er) {
                Console.WriteLine($"Não existe produto com este código no estoque.");
            }
            
            break;

        case 3: // Atualização de estoque
            Console.WriteLine($"Informe o código: ");
            code = Console.ReadLine();

            product = Utilities.getProductByCode(code, products_list);

            try {
                product = Utilities.getProductByCode(code, products_list);

                Console.WriteLine($"Informe a nova quantidade: ");
                amount = int.Parse(Console.ReadLine());

                if ( amount > product.Amount ) {
                    Console.WriteLine($"A quantidade fornecida é superior à quantidade presente em estoque.");
                    
                } else {
                    product_index = products_list.IndexOf(product);
                    products_list[product_index].Amount = amount;
                    Console.WriteLine("Estoque do produto atualizado com sucesso!");
                }
            } 
            catch (InvalidOperationException er) {
                Console.WriteLine($"Não existe produto com este código no estoque.");
            }

            break;

        case 4: // Relatórios
            Console.WriteLine($@"Opções de relatório: ");
            menu_options = new string[] {"Retornar ao menu principal",
                            "Lista de produtos abaixo do estoque",
                            "Lista de produtos com valores mínimo e máximo",
                            "Valor total do estoque e valor total de cada produto"}
                            .ToList();

            do {
                Utilities.montarMenu(menu_options);
                Console.Write($"\nSua opção: ");
                user_option = int.Parse(Console.ReadLine());

                switch (user_option)
                {
                    case 0:
                        Console.WriteLine($"Retornando...");
                        break;
                        
                    case 1:
                        Console.WriteLine($"Informe a nova quantidade: ");
                        amount = int.Parse(Console.ReadLine());

                        Utilities.getProductsBelowLimit(amount, products_list);

                        break;

                    case 2:
                        Console.WriteLine($"Informe o mínimo: ");
                        min_amount = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Informe o máximo: ");
                        max_amount = int.Parse(Console.ReadLine());

                        Utilities.getProductsMinMax(min_amount, max_amount, products_list);

                        break;

                    case 3:
                        Utilities.getTotalAmountAll(products_list);

                        break;

                    default:
                        Console.WriteLine($"Insira um valor entre 0 e {menu_options.Count}");

                        break;
                }
                
               
            } while (user_option != 0);

            break;    

        default:
            Console.WriteLine($"Insira um número entre 0 e {menu_options.Count}");
            break;
    }
    Console.WriteLine(); // Quebrar linha por formatação
} while (user_option != 0);