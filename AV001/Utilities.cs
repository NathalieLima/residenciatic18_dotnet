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

    public static bool isValidCPF(string cpf) {
        if (cpf.Length != 11) {
            throw new Exception("Um CPF deve ter 11 caracteres.");
            return false;
        }
        else 
        {
            if ( !cpf.All(char.IsDigit) ) {
                throw new Exception("Um CPF deve ser composto somente por números.")
                return false;
            }
        }

        return true;
    }
}