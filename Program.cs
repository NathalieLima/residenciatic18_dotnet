/* Desenvolver um sistema de gerenciamento de tarefas que permita aos usuários criar, 
visualizar e gerenciar tarefas. */

using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

// Declaração de variáveis

List<object[]> todo_tasks = new List<object[]>();
List<object[]> done_tasks = new List<object[]>();
var all_tasks = new List<object[]>();
string user_option, 
        title, 
        description, 
        str_due_date, 
        str_task,
        flag,
        keywords;
int task_index;
bool is_pendente;
DateTime dt_due_date,
        now = DateTime.Now;
object[] obj_task,
         found_item;

// Montar menu e exibi-lo

string[] options = {"Sair do programa",
                "Criar uma tarefa", 
                "Visualizar tarefa", 
                "Listar tarefas pendentes", 
                "Listar tarefas concluídas",
                "Listar todas as tarefas",
                "Marcar tarefa como concluída",
                "Encontrar tarefa(s)",
                "Editar tarefa",
                "Excluir tarefa",
                "Calcular número de tarefas pendentes",
                "Calcular número de tarefas concluídas",
                "Visualizar a tarefa mais antiga",
                "Visualizar a tarefa mais recente",
                "Visualizar tarefas vencidas"};

Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ABAIXO:");

for (int i = 1; i < options.Length; i++) 
{
    Console.WriteLine($"{i}. {options[i]}");
}

Console.WriteLine($"{0}. {options[0]}");

// Laço de execução do programa

do {
    Console.Write("\nEscolha uma opção: ");
    user_option = Console.ReadLine();

    Console.WriteLine();
    Console.WriteLine(options[int.Parse(user_option)].ToUpper());

    switch (user_option) 
    {
        case "0":   // Finalização do programa
            Console.WriteLine("Fim do programa!");
            break;

        case "1": // Criar tarefa
            Console.Write("Título: ");
            title = Console.ReadLine().ToUpper();

            Console.Write("Descrição: ");
            description = Console.ReadLine();

            Console.Write("Data de vencimento (DD/MM/YYYY): ");
            str_due_date = Console.ReadLine();
            dt_due_date = DateTime.Parse(str_due_date);

            obj_task = new object[] {title, description, dt_due_date};
            
            todo_tasks.Add(obj_task);
            Console.WriteLine("Tarefa registrada com sucesso!");

            break;

        case "2": // Visualizar tarefa
            Console.Write("Título da tarefa: ");
            title = Console.ReadLine().ToUpper();

            all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
            all_tasks.AddRange(todo_tasks);
            all_tasks.AddRange(done_tasks);

            task_index = -1;
            
            for (int i = 0; i < all_tasks.Count && task_index == -1; i++) 
            {
                if (all_tasks[i][0].ToString() == title) 
                {
                    task_index = i;
                    found_item = all_tasks[i];

                    Console.WriteLine($"Tarefa: {found_item[0]} - {found_item[1]} | {found_item[2]}");
                }
            }

            if (task_index == -1) {
                Console.WriteLine("Não existe tarefa com este título registrada.");
            }

            break;

        case "3": // Listar tarefas pendentes
            
            if (todo_tasks.Count == 0) {
                Console.WriteLine("Não há tarefas pendentes registradas.");
                
            } else {
                foreach (object[] item in todo_tasks) {
                    Console.WriteLine($"{item[0]} - {item[1]} | {item[2]}");
                }
            }

            break;

        case "4": // Listar tarefas concluídas
            if (done_tasks.Count == 0) {
                Console.WriteLine("Não há tarefas concluídas registradas.");
                
            } else {
                foreach (object[] item in done_tasks) {
                    Console.WriteLine($"{item[0]} - {item[1]} | {item[2]}");
                }
            }

            break;

        case "5": // Listar todas as tarefas
            all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
            all_tasks.AddRange(todo_tasks);
            all_tasks.AddRange(done_tasks);

            if (all_tasks.Count == 0) {
                Console.WriteLine("Não há tarefas registradas.");
                
            } else {
                foreach (object[] item in all_tasks) {
                    Console.WriteLine($"{item[0]} - {item[1]} | {item[2]}");
                }
            }

            break;

        case "6": // Marcar como concluída
            Console.Write("Título da tarefa: ");
            title = Console.ReadLine().ToUpper();

            task_index = -1;

            for (int i = 0; i < todo_tasks.Count && task_index == -1; i++) {
                if (todo_tasks[i][0].ToString() == title) {
                    task_index = i;
                }
            }

            if (task_index != -1) {
                done_tasks.Add(todo_tasks[task_index]); // Adicionar tarefa em concluídas
                todo_tasks.RemoveAt(task_index);        // Remover tarefa de pendentes

                Console.WriteLine("Tarefa marcada com sucesso!");
                
            } 
            else {
                Console.WriteLine("Não existe tarefa com este título registrada.");
            }

            break;

        case "7": // Encontrar tarefa através de palavra-chave
            do {
                Console.Write("Informe palavra(s)-chave(s) da tarefa: ");
                keywords = Console.ReadLine();

                all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
                all_tasks.AddRange(todo_tasks);
                all_tasks.AddRange(done_tasks);
                flag = false;

                foreach (var item in all_tasks) 
                {
                    str_task = ($"{item[0].ToString()} - {item[1].ToString()}");

                    if ( str_task.Contains(keywords) ) {
                        Console.WriteLine(str_task);  
                        flag = true;
                    }
                }

                if (!flag) {
                    Console.WriteLine("Nenhum resultado de sua busca.");
                }

                Console.Write("\nDeseja pesquisar mais uma vez (s/n)? ");
                flag = Console.ReadLine();
            } while (flag != "n");
            
            break;

        case "8": // Editar tarefa
            Console.Write("Título: ");
            title = Console.ReadLine().ToUpper();

            is_pendente = false;
            task_index = -1;

            for (int i = 0; i < todo_tasks.Count && task_index == -1; i++) {
                if (todo_tasks[i][0].ToString() == title) 
                {
                    is_pendente = true;
                    task_index = i;
                }
            }

            if (task_index == -1) 
            {
                for (int i = 0; i < done_tasks.Count && task_index == -1; i++) {
                    if (done_tasks[i][0].ToString() == title) 
                    {
                        task_index = i;
                    }
                }

                if (task_index == -1) {
                    Console.WriteLine("Não existe tarefa com este título registrada.");
                    break;
                }
            }

            Console.WriteLine("Informe os novos valores!");

            Console.Write("Novo título: ");
            title = Console.ReadLine().ToUpper();

            Console.Write("Nova descrição: ");
            description = Console.ReadLine();

            Console.Write("Nova data de vencimento (DD/MM/YYYY): ");
            str_due_date = Console.ReadLine();
            dt_due_date = DateTime.Parse(str_due_date);

            obj_task = new object[] {title, description, dt_due_date};

            if (is_pendente) {
                todo_tasks[task_index] = obj_task;
            } else {
                done_tasks[task_index] = obj_task;
            }

            Console.WriteLine("Tarefa editada com sucesso!");

            break;

        case "9": // Excluir tarefas
            Console.Write("Título da tarefa: ");
            title = Console.ReadLine().ToUpper();

            task_index = -1;

            for (int i = 0; i < todo_tasks.Count && task_index == -1; i++) {
                if (todo_tasks[i][0].ToString() == title) 
                {
                    task_index = i;
                    todo_tasks.RemoveAt(task_index);  

                    Console.WriteLine("Tarefa excluída com sucesso!");
                }
            }

            if (task_index == -1) 
            {
                for (int i = 0; i < done_tasks.Count && task_index == -1; i++) {
                    if (done_tasks[i][0].ToString() == title) 
                    {
                        task_index = i;
                        done_tasks.RemoveAt(task_index);    

                        Console.WriteLine("Tarefa excluída com sucesso!"); 
                    }
                }

                if (task_index == -1) {
                    Console.WriteLine("Não existe tarefa com este título registrada.");
                }
            }

            break;

        case "10": // Quantidade de tarefas pendentes
            Console.WriteLine($"Número de tarefas pendentes: {todo_tasks.Count}");

            break;

        case "11": // Quantidade de tarefas concluídas
            Console.WriteLine($"Número de tarefas concluídas: {done_tasks.Count}");

            break;

        case "12": // Data mais antiga
            DateTime older_date = now;
            all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
            all_tasks.AddRange(todo_tasks);
            all_tasks.AddRange(done_tasks);

            foreach (var item in all_tasks) 
            {
                DateTime date_item = DateTime.Parse(item[2].ToString());

                if ( date_item < older_date ) {
                    older_date = date_item;  
                } 
                
            }

            Console.WriteLine($"Data mais antiga: {older_date.Date}");

            break;

        case "13": // Data mais recente
            DateTime recent_date = DateTime.Parse("01/01/2000");
            all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
            all_tasks.AddRange(todo_tasks);
            all_tasks.AddRange(done_tasks);

            foreach (var item in all_tasks) 
            {
                DateTime date_item = DateTime.Parse(item[2].ToString());

                if ( date_item > recent_date ) {
                    recent_date = date_item;  
                } 
            }

            Console.WriteLine($"Data mais recente: {recent_date.Date}");

            break;

        default:
            Console.WriteLine($"Insira um número entre 0 e {options.Length}");
            break;
    }

} while (user_option != "0");