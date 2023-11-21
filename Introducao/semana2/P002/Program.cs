/*
Desenvolver um sistema de gerenciamento de tarefas que permita aos usuários criar, 
visualizar e gerenciar tarefas.
*/
//transformar p tolower


// montar e exibir menu

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
                "Calcular número de tarefas concluídas",
                "Calcular número de tarefas pendentes",
                "Visualizar a tarefa mais antiga",
                "Visualizar a tarefa mais recente"};

Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ABAIXO:");

for (int i = 1; i < options.Length; i++) 
{
    Console.WriteLine($"{i}. {options[i]}");
}

Console.WriteLine($"{0}. {options[0]}");

List<object[]> todo_tasks = new List<object[]>();
List<object[]> done_tasks = new List<object[]>();
string user_option, 
        title, 
        description, 
        due_date, 
        str_task,
        flag,
        keywords;
int task_index;
object[] obj_task,
         found_item;
var all_tasks = new List<object[]>();


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
            title = Console.ReadLine();

            Console.Write("Descrição: ");
            description = Console.ReadLine();

            Console.Write("Data de vencimento: ");
            due_date = Console.ReadLine();

            obj_task = new object[] {title.ToUpper(), description, due_date};
            
            todo_tasks.Add(obj_task);

            break;

        case "2": // Visualizar tarefa
            Console.Write("Título da tarefa: ");
            title = Console.ReadLine();

            all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
            all_tasks.AddRange(todo_tasks);
            all_tasks.AddRange(done_tasks);

            task_index = -1;

            for (int i = 0; i < all_tasks.Count && task_index == -1; i++) 
            {
                if (done_tasks[i][0] == title) 
                {
                    task_index = i;
                    found_item = all_tasks[i];
                }
            }

            //Console.WriteLine($"{found_item}");
            

            //str_task = found_item[0].ToUpper() + " - " + found_item[1] + " | " + found_item[2];
            str_task = "ola";

            Console.WriteLine($"Tarefa: {str_task}");

            break;

        case "3":   // Listar tarefas concluídas
            // foreach (object[] item in done_tasks) {
            //     str_task = ($"{item[0].ToUpper()} - {item[1]} | {item[2]}");
            //     Console.WriteLine(str_task);
            // }

            break;

        case "4":   // Listar tarefas pendentes
            foreach (object[] item in todo_tasks) {
                Console.WriteLine($"{item[0]} - {item[1]} | {item[2]}");
            }

            break;

        case "5": // Listar todas as tarefas
            all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
            all_tasks.AddRange(todo_tasks);
            all_tasks.AddRange(done_tasks);

            // foreach (object[] item in all_tasks) {
            //     str_task = ($"{item[0].ToUpper()} - {item[1]} | {item[2]}");
            //     Console.WriteLine(str_task);
            // }

            break;

        case "6": // Marcar como concluída
            Console.Write("Título da tarefa: ");
            title = Console.ReadLine();

            task_index = -1;

            for (int i = 0; i < todo_tasks.Count && task_index == -1; i++) {
                if (todo_tasks[i][0] == title) {
                    task_index = i;
                }
            }

            if (task_index != -1) {
                done_tasks.Add(todo_tasks[task_index]); // Adicionar tarefa em concluídas
                todo_tasks.RemoveAt(task_index);        // Remover tarefa de pendentes
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

                // foreach (var item in all_tasks) 
                // {
                //     str_task = ($"{item[0].ToUpper()} - {item[1]}");

                //     if ( str_task.Contains(keywords) ) {
                //         Console.WriteLine(str_task);  
                //     }
                // }

                Console.Write("Deseja pesquisar mais uma vez (s/n)? ");
                flag = Console.ReadLine();
            } while (flag != "n");
            
            break;

        case "8": // Editar tarefa
            Console.Write("Título: ");
            title = Console.ReadLine();

            Console.Write("Descrição: ");
            description = Console.ReadLine();

            Console.Write("Data de vencimento: ");
            due_date = Console.ReadLine();

            obj_task = new object[] {title.ToUpper(), description, due_date};
            task_index = -1;

            all_tasks = new List<object[]>(todo_tasks.Count + done_tasks.Count);
            all_tasks.AddRange(todo_tasks);
            all_tasks.AddRange(done_tasks);

            for (int i = 0; i < all_tasks.Count && task_index == -1; i++) 
            {
                if (done_tasks[i][0] == title) 
                {
                    task_index = i;
                    all_tasks[i] = obj_task;
                }
            }

            break;

        case "9": // Excluir tarefas
            Console.Write("Título da tarefa: ");
            title = Console.ReadLine();

            task_index = -1;

            for (int i = 0; i < todo_tasks.Count && task_index == -1; i++) {
                if (todo_tasks[i][0] == title) 
                {
                    task_index = i;
                    todo_tasks.RemoveAt(task_index);  
                }
            }

            if (task_index == -1) {
                Console.WriteLine("Tarefa excluída com sucesso!");
            } 
            else {
                for (int i = 0; i < done_tasks.Count && task_index == -1; i++) {
                    if (done_tasks[i][0] == title) 
                    {
                        task_index = i;
                        done_tasks.RemoveAt(task_index);     
                    }
                }

                if (task_index == -1) {
                    Console.WriteLine("Tarefa excluída com sucesso!");
                } 
                else {
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

        default:
            Console.WriteLine($"Insira um número entre 0 e {options.Length}");
            break;
    }

} while (user_option != "0");