using TesteNameSpace;
using TesteNameSpace.Exceptions;

List<string> menu_options = new List<string>();
bool flag = false,
     finish_program = false;
string code, name;
double price;
int user_option = 0,
    io_amount,
    amount,
    min_amount,
    max_amount,
    product_index;
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
            finish_program = true;
            break;
            
        case 1: // Cadastro de produto
            Product new_product = new Product();

            do {
                Console.Write($"Informe o código: ");
                code = Console.ReadLine();
                flag = false;

                if ( Utilities.isExistingCode(code, products_list) ) {
                    Console.WriteLine("Este código já existe, entre com um diferente!");
                    
                    flag = true;
                } 
                else {
                    try {
                        new_product.Code = code;
                    } 
                    catch (Exception error) {
                        Console.WriteLine(error.Message);

                        flag = true;
                    }
                }
            } while (flag);
            
            do {
                Console.Write($"Informe o nome: ");
                name = Console.ReadLine();
                flag = false;

                try {
                    new_product.Name = name;
                } 
                catch (Exception error) {
                    Console.WriteLine(error.Message);

                    flag = true;
                }
            } while (flag);
            
            do {
                Console.Write($"Informe a quantidade: ");
                amount = int.Parse(Console.ReadLine());
                flag = false;

                try {
                    new_product.Amount = amount;
                } 
                catch (Exception error) {
                    Console.WriteLine(error.Message);

                    flag = true;
                }
            } while (flag);

            do {
                Console.Write($"Informe o preço: ");
                price = double.Parse(Console.ReadLine());
                flag = false;

                try {
                    new_product.Price = price;
                } 
                catch (Exception error) {
                    Console.WriteLine(error.Message);

                    flag = true;
                }
            } while (flag);

            products_list.Add(new_product);

            Console.WriteLine($"\nEste produto foi cadastrado com sucesso!");
            break;

        case 2: // Consulta de produto
            Product product = new Product();

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
            Product att_product = new Product();

            Console.Write($"Informe o código: ");
            code = Console.ReadLine();

            att_product = Utilities.getProductByCode(code, products_list);

            try {
                att_product = Utilities.getProductByCode(code, products_list);

                Console.Write($"Informe a nova quantidade: ");
                amount = int.Parse(Console.ReadLine());

                Console.Write($"Informe se é entrada [1] ou saída [2] de itens: ");
                io_amount = int.Parse(Console.ReadLine());

                if ( amount > att_product.Amount && io_amount == 2 ) {
                    Console.WriteLine($"A quantidade fornecida é superior à quantidade presente em estoque.");
                } else {
                    product_index = products_list.IndexOf(att_product);
                    products_list[product_index].Amount = amount;
                    Console.WriteLine("Estoque do produto atualizado com sucesso!");
                }
            } 
            catch (Exception er) {
                Console.WriteLine($"Não existe produto com este código no estoque.");
            }

            break;

        case 4: // Relatórios
            if (Utilities.isAnyProduct(products_list))
            {
                menu_options = new string[] {"Retornar ao menu principal",
                                "Lista de produtos abaixo do estoque",
                                "Lista de produtos com valores mínimo e máximo",
                                "Valor total do estoque e valor total de cada produto"}
                                .ToList();

                do {
                    Console.WriteLine($"\nOpções de relatório: ");
                    Utilities.montarMenu(menu_options);
                    Console.Write($"\nSua opção: ");
                    user_option = int.Parse(Console.ReadLine());

                    switch (user_option)
                    {
                        case 0:
                            Console.WriteLine($"Retornando...");
                            break;
                            
                        case 1:
                            Console.Write($"Informe o limite: ");
                            amount = int.Parse(Console.ReadLine());

                            Utilities.getProductsBelowLimit(amount, products_list);

                            break;

                        case 2:
                            Console.Write($"Informe o mínimo: ");
                            min_amount = int.Parse(Console.ReadLine());

                            Console.Write($"Informe o máximo: ");
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
            }
            else {
                Console.WriteLine($"Não há produtos cadastrados para a realização de relatórios.");
            }

            break;

        default:
            Console.WriteLine($"Insira um número entre 0 e {menu_options.Count}");
            break;
    }
    Console.WriteLine(); // Quebrar linha por formatação
} while (!finish_program);