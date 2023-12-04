namespace Classes;

static class Utilities 
{
    public static void montarMenu(List<string> options) 
    {
        options.Select((x, index) => new { Index = index, Option = x })
        .ToList()
        .ForEach(item => Console.WriteLine($"{item.Index + 1}. {item.Option}"));

        Console.WriteLine("0. Sair do programa");
    }

    public static int getMenuLength(List<string> options) {
        return options.Count;
    }

    public static (bool Error, string Message) isValidCPF(string cpf) 
    {
        var tupla_erro = (error: false, message: "");

        if (cpf.Length != 11) 
        {
            tupla_erro.error = true;
            tupla_erro.message = "Um CPF deve ter 11 caracteres.";

            return tupla_erro;
        }
        else 
        {
            if ( !cpf.All(char.IsDigit) ) 
            {
                tupla_erro.error = true;
                tupla_erro.message = "Um CPF deve ser composto somente por números.";

                return tupla_erro;
            }
        }

        return tupla_erro;
    }

    public static bool isEmptyValue(string value) {
        return string.IsNullOrEmpty(value);
    }

    public static DateTime convertToDateTime(string date_string) {
        DateTime data;

        try {
            DateTime.TryParse(date_string, out data);
        }
        catch {
            throw new Exception("Data inválida!");
        }

        return data;
    }

    public static string capitalize(string value) 
    {
        char[] delimitadores = {' '};
        List<string> names = value.Split(delimitadores).ToList();
        names = names.Select(name => char.ToUpper(name[0]) + name.Substring(1)).ToList();

        return string.Join(" ", names);
    }

    private static bool isUniqueCPF(string CPF, List<Pessoa> list) {
        Console.WriteLine($"{CPF} {list.Any(item => item.CPF == CPF)}");
        list.Where(item => item.CPF == CPF).ToList()
        .ForEach(item => Console.WriteLine($"{item.CPF}"));
        
        return !list.Any(item => item.CPF == CPF);
    }

    private static bool isUniqueCRM(string CRM, List<Medico> list_medicos) {
        return !list_medicos.Any(item => item.CRM == CRM);
    }

    public static void adicionarPaciente(Paciente paciente, List<Paciente> list) 
    {
        if ( isUniqueCPF(paciente.CPF, list.Cast<Pessoa>().ToList()) ) {
            list.Add(paciente);
        } else {
            throw new Exception("Já existe um CPF igual a esse no sistema.");
        }
    }

    public static void adicionarMedico(Medico medico, List<Medico> list) 
    {
        if ( isUniqueCPF(medico.CRM, list.Cast<Pessoa>().ToList()) ) 
        {
            if ( isUniqueCRM(medico.CRM, list) ) {
                list.Add(medico);
            } else {
                throw new Exception("Já existe um CRM igual a esse no sistema.");
            }

            list.Add(medico);

        } else {
            throw new Exception("Já existe um CPF igual a esse no sistema.");
        }
    }
}