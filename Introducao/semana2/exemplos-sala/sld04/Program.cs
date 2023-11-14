// #region Teste de propriedades e métodos de string

// string name = "Náthalie";

// Console.WriteLine($"Hello, {name.Contains("i")}");
// Console.WriteLine($"Hello, {name.ToUpper()}");
// Console.WriteLine($"Hello, {name.Length}");
// Console.WriteLine($"Hello, {string.IsNullOrWhiteSpace(name)}");
// Console.WriteLine($"Hello, {string.IsNullOrWhiteSpace("\n Náthalie")}");

// string[] arr = name.Split("l");

// foreach (string pedaco in arr)
// {
//     Console.WriteLine(pedaco);
// }

// #endregion

#region Teste de propriedades e métodos de listas

List<string> lista_nomes = new List<string>(); // reservar espaço de memória
lista_nomes.Add("Náthalie");
lista_nomes.Add("Maria");
lista_nomes.Add("Joseph");
lista_nomes.Add("Mario");
lista_nomes.Add("Clary");
lista_nomes.Remove("Joseph");

foreach (string nome in lista_nomes)
{
    Console.WriteLine(nome);
}

Console.WriteLine(lista_nomes.Count);


#endregion

#region 

DateTime my_birth = new DateTime(2023, 12, 15);
Console.WriteLine(my_birth.DayOfWeek);

#endregion

#region Exercício 1 - Dividir data string em dia, mês, ano

// parse e split pra fazer rápido

string data = Console.ReadLine();

#endregion

#region Exc 3 - (ver isso com lambda e where)

#endregion