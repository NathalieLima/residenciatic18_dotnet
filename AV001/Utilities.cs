namespace Classes;

static class Utilities 
{
    public static void montarMenu(List<string> options) {
        options.Select((x, index) => new { Index = index, Option = x })
        .ToList()
        .ForEach(item => Console.WriteLine($"{item.Index}. {item.Option}"));
    }

    public static int getMenuLength(List<string> options) {
        return options.Length;
    }

    public static bool isUniqueValue(string value, var list) {
        return list.Any(item => item == value);
    }

    public static var isValidCPF(string cpf, var list) {
        if (cpf.Length != 11) {
            var tupla_erro = (error: true; message: "Um CPF deve ter 11 caracteres.");

            return tupla_erro;
        }
        else 
        {
            if ( !cpf.All(char.IsDigit) ) {
                var tupla_erro = (error: true; message: "Um CPF deve ser composto somente por números.");

                return tupla_erro;
            }
            else 
            {
                if ( !isUniqueValue(cpf, list) ) {
                    var tupla_erro = (error: true; message: "Um CPF igual a esse já foi cadastrado.");

                    return tupla_erro;
                }
            }
        }

        return {erro: false; message: ""};
    }

    public static bool isEmptyField(string value) {
        return value.Empty;
    }

    public static int calcularIdade(DateTime data_nascimento) {
        return 10;
    } 
}