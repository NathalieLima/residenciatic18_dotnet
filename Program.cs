#region 2. Tipos de Dados

Console.WriteLine("\n EXERCÍCIO 2");

sbyte tipo_sbyte = 127;
byte tipo_byte = 255;
short tipo_short = short.MaxValue;
ushort tipo_ushort = 65535;
int tipo_int = 2147483647;
uint tipo_uint = 4294967295;
long tipo_long = 9223372036854775807;
ulong tipo_ulong = 18446744073709551615;

Console.WriteLine($"Valor de tipo_sbyte: {tipo_sbyte}");
Console.WriteLine($"Valor de tipo_byte: {tipo_byte}");
Console.WriteLine($"Valor de tipo_short: {tipo_short}");
Console.WriteLine($"Valor de tipo_ushort: {tipo_ushort}");
Console.WriteLine($"Valor de tipo_int: {tipo_int}");
Console.WriteLine($"Valor de tipo_uint: {tipo_uint}");
Console.WriteLine($"Valor de tipo_long: {tipo_long}");
Console.WriteLine($"Valor de tipo_ulong: {tipo_ulong}");

#endregion


#region 3. Conversão de Tipos de Dados

Console.WriteLine("\n EXERCÍCIO 3");

double tipo_double = 3.14;

// int tipo_inteiro = tipo_double;
int tipo_inteiro = Convert.ToInt32(tipo_double);
Console.WriteLine(tipo_inteiro);

tipo_inteiro = (int)tipo_double;
Console.WriteLine(tipo_inteiro);

//tipo_inteiro = int.Parse(tipo_double);
var is_convertido = int.TryParse("asdaasd", out tipo_inteiro);
Console.WriteLine($"{tipo_inteiro} {is_convertido}");

/* Conclusão:
Neste caso, a conversão precisa ser explícita, uma vez que são dados incompatíveis,
então são usados Convert e (int). Também ocorre o truncamento, de modo a perder a precisão.
Da maneira tradicional ou com apenas o Parse o compilador aponta erro de conversão implícita.
*/

#endregion


#region 4. Operadores Aritméticos

Console.WriteLine("\n EXERCÍCIO 4");

int x = 10, y = 3;

int adicao = x + y;
int subtracao = x - y;
int multiplicacao = x * y;
var divisao = x / y;

Console.WriteLine($@"Resultados:
 Adição: {adicao}
 Subtração: {subtracao}
 Multiplicação: {multiplicacao}
 Divisão: {divisao}");

#endregion


#region 5. Operadores de Comparação

Console.WriteLine("\n EXERCÍCIO 5");

int a = 5, 
    b = 8;

Console.WriteLine($"a é maior que b? {a > b}");

#endregion


#region 6. Operadores de Igualdade

Console.WriteLine("\n EXERCÍCIO 6");

string str1 = "Hello", 
        str2 = "World";

Console.WriteLine($"str1 é igual a str2? {str1 == str2}");

#endregion


#region 7. Operadores Lógicos

Console.WriteLine("\n EXERCÍCIO 7");

bool condicao1 = true,
     condicao2 = true,
     condicao3 = condicao1 && condicao2;

Console.WriteLine($"Ambas as condições {(condicao3 ? "são" : "não são")} verdadeiras.");

#endregion


#region 8. Desafio de Mistura de Operadores

Console.WriteLine("\n EXERCÍCIO 8");

int num1 = 7, 
    num2 = 3, 
    num3 = 10;
bool teste1 = num1 > num2,
     teste2 = num3 == num1 + num2;

Console.WriteLine($"{num1} {(teste1 ? "é" : "não é")} maior do que {num2}");
Console.WriteLine($"{num3} {(teste2 ? "é" : "não é")} igual a {num1} + {num2}");

#endregion