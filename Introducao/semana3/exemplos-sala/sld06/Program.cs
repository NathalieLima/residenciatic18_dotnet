/*
Crie um programa que solicita ao usuário que insira um número. Utilize um bloco try-catch para
lidar com a possível exceção gerada se o usuário inserir algo que não seja um número. No bloco
catch, exiba uma mensagem amigável informando ao usuário que um número válido deve ser
inserido.
*/

int number;

try {
    Console.Write("Insira um número: ");
    number = int.Parse(Console.ReadLine());
} catch (Exception er) {
    Console.WriteLine($"Insira um número válido!");
    
}
finally {
    Console.WriteLine($"{number}");
}


