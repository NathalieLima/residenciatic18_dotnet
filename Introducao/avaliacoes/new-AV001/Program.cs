// faltou ver: validação data, método construtor, testar médico
// testar required

using Classes;
using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");


List<string> menu_options = new List<string>() 
{
    "Médicos com idade entre dois valores",
    "Pacientes com idade entre dois valores",
    "Pacientes do sexo informado pelo usuário",
    "Pacientes em ordem alfabética",
    "Pacientes cujos sintomas contenha texto informado pelo usuário", 
    "Médicos e Pacientes aniversariantes do mês informado",
    "Add usuários"
}; 
int menu_size = Utilities.getMenuLength(menu_options);
int user_option;
string input;
Type tipo = typeof(Paciente);
int qtd_properties = tipo.GetProperties().Count();
int qtd_test_itens = 5;
List<Medico> medicos_list = new List<Medico>();
List<Paciente> pacientes_list = new List<Paciente>();

do {
    Utilities.montarMenu(menu_options);

    Console.Write($"\nSua opção: ");
    input = Console.ReadLine();

    // Tentar

    if ( !int.TryParse(input, out user_option) ) {
        user_option = menu_size + 1;
    }
    
    switch (user_option) 
    {
        case 0:
            Console.WriteLine($"Fim do programa!");
            break;

        case 7:
            string[,] test_values = new string[,] 
            {
                // {"Nome", "DataNascimento", "CPF", "Sexo", "Sintomas"}
                {"náthalie Lima", "01/09/1987", "12345678901", "feminino", "Febre, Tosse, Cansaço"},
                {"master santos", "03/22/1975", "98765432102", "masculino", "Dor de cabeça, Febre"},
                {"Syndra Oliveira", "09/05/1992", "11122233303", "feminino", "Dor de garganta, Cansaço"},
                {"volibear pereira", "32/10/1980"
                , "55566677704", "masculino", "Perda de olfato ou paladar, Tosse"},
                {"Annie silva", "09/09/1965", "12345678902", "feminino", "Febre, Cansaço"}
            };

            for ( int i = 0; i < test_values.GetLength(0); i++ )
            {
                Paciente novo_paciente = new Paciente();
                Console.WriteLine($"\n---------- PACIENTE {i + 1}");
                Console.WriteLine($"{test_values[i, 0]} {test_values[i, 1]} {test_values[i, 2]} {test_values[i, 3]} {test_values[i, 4]}");
                
                try {
                    novo_paciente.Nome = test_values[i, 0];
                    Console.WriteLine($"Propriedade 'Nome' modificada com sucesso!");
                    
                } catch (Exception error) {
                    Console.WriteLine($"{error.Message}");
                }

                try {
                        DateTime date = Utilities.convertToDateTime(test_values[i, 1]);
                        novo_paciente.DataNascimento = date;
                 
                        Console.WriteLine($"Propriedade 'DataNascimento' modificada com sucesso!");
                } catch (Exception error) {
                    Console.WriteLine($"{error.Message}");
                }

                try {
                    novo_paciente.CPF = test_values[i, 2];
                    Console.WriteLine($"Propriedade 'CPF' modificada com sucesso!");
                    
                } catch (Exception error) {
                    Console.WriteLine($"{error.Message}");
                }

                try {
                    novo_paciente.Sexo = test_values[i, 3];
                    Console.WriteLine($"Propriedade 'Sexo' modificada com sucesso!");
                    
                } catch (Exception error) {
                    Console.WriteLine($"{error.Message}");
                }

                try {
                    novo_paciente.Sintomas = test_values[i, 4];
                    Console.WriteLine($"Propriedade 'Sintomas' modificada com sucesso!");
                    
                } catch (Exception error) {
                    Console.WriteLine($"{error.Message}");
                }

                try {
                    Utilities.adicionarPaciente(novo_paciente, pacientes_list);
                } catch (Exception error) {
                    Console.WriteLine($"ERRINHO: {error.Message}");
                }
            }

            break;

        case 1:
            GeradorRelatorio.getMedicosIdades(0, 100, medicos_list);
            break;

        case 2:
            GeradorRelatorio.getPacientesIdades(0, 100, pacientes_list);
            break;

        case 3:
            GeradorRelatorio.getPacientesBySexo("feminino", pacientes_list);
            break;

        case 4:
            GeradorRelatorio.getPacientesOrderByNome(pacientes_list);
            break;

        case 5:
            GeradorRelatorio.getPacientesBySintomas("Febre", pacientes_list);
            break;

        case 6:
            List<Pessoa> lista = new List<Pessoa>();
            lista.AddRange(medicos_list.Cast<Pessoa>().ToList());
            lista.AddRange(pacientes_list.Cast<Pessoa>().ToList());
            
            GeradorRelatorio.getAniversariantesMes(9, lista);
            break;

        
        default:
            Console.WriteLine($"Insira um número entre 0 e {menu_size}.");
            break;
    }

    Console.WriteLine();
} while (user_option != 0);