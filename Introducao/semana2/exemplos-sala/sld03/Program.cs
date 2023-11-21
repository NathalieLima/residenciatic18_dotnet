#region exemplo1

string[] colecao= {"Item1", "Item2", "Item3", "Item4"};

foreach (string item in colecao) 
{
    // item = "maria" + item;
    Console.WriteLine(item);
}

#endregion

#region Readline example

Console.WriteLine("Please enter your name: ");
string? name = Console.ReadLine();
Console.WriteLine($"Hello, {name}!");

#endregion

#region Exercício 1 - Divisíveis por 3 ou 4

// assim funciona, mas é ineficiente quando 

for (var i = 1; i <= 30; i++)
{
    // if ( !(i % 3) || !(i % 4) ) {
    //     Console.WriteLine($"{i} é divísivel por 3 ou 4!");
    // }
}

#endregion

#region Exercício 2 - Fibonacci

int num1 = 0, 
    num2 = 1, 
    sum = 0;

for (; sum <= 100; ) 
{
    Console.WriteLine(sum);

    num1 = num2;
    num2 = sum;
    sum = num1 + num2;
}

#endregion

#region Exercício 3 - Até nível 8

//string num = Console.ReadLine();
int num = 8;

for (int i = 1; i <= num; i++)
{
    Console.WriteLine();

    for (int j = 1; j <= i; j++) {
        Console.Write(i * j + " ");
    }

}
// ver sobre, tb aquele exe la de quadrado e tal
#endregion