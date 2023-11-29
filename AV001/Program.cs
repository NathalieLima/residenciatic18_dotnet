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
    "Médicos e Pacientes aniversariantes do mês informado"
}; 
int user_option;
List<Medico> medicos_list = new List<Medico>();
List<Paciente> pacientes_list = new List<Paciente>();
Medico novo_medico = new Medico();
Medico novo_paciente = new Paciente();

do {
    Utilities.montarMenu(menu_options);

    Console.Write($"Sua opção: ");
    user_option = Console.ReadLine();
    
    switch (user_option) 
    {
        case 0:
            Console.WriteLine($"Fim do programa!");
            break;

        case 1:
            novo_medico = 
            
        
        default:
            Console.WriteLine($"Insira um número entre 0 e {Utilities.getMenuLength(menu_options)}");
            
            
    }

} while (user_option != 0);