using Classes;

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

do {
    Utilities.montarMenu(menu_options);

    Console.Write($"Sua opção: ");
    user_option = Console.ReadLine();
    

} while (user_option != 0);