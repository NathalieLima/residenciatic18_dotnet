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

    public static (bool, string) isValidCPF(string cpf, List<Pessoa> list) {
        var tupla_erro = (error: false, message: "");

        if (cpf.Length != 11) {
            tupla_erro.error = true;
            tupla_erro.message = "Um CPF deve ter 11 caracteres.";

            return tupla_erro;
        }
        else 
        {
            if ( !cpf.All(char.IsDigit) ) {
                tupla_erro.error = true;
                tupla_erro.message = "Um CPF deve ser composto somente por números.";

                return tupla_erro;
            }
        }

        return tupla_erro;
    }

    public static bool isEmptyField(string value) {
        return value.Empty;
    }

    public static int calcularIdade(DateTime data_nascimento) {
        return 10;
    } 

    private static bool isUniqueCPF(string CPF, List<Pessoa> list) {
        return list.Any(item => item.CPF == CPF);
    }

    private static bool isUniqueCRM(string CRM, List<Medico> list_medicos) {
        return list_medicos.Any(item => item.CRM == CRM);
    }

    public static void adicionarPaciente(Paciente paciente, List<Paciente> list) {
        if ( isUniqueCPF(paciente.CPF, list) ) {
            list.Add(paciente);
        } else {
            throw new Exception("Já existe um CPF igual a esse no sistema.");
        }
    }

    public static void adicionarMedico(Medico medico, List<Medico> list) {
        if ( isUniqueCPF(medico.CRM, list) ) 
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