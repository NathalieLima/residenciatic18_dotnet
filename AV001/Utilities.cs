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
        }

        return {erro: false; message: ""};
    }

    public static boolean isEmptyField(string value) {
        return value.Empty;
    }

    public static int calcularIdade(DateTime data_nascimento) {
        return 10;
    } 

    private static boolean isUniqueCPF(string CPF, var list) {
        return list.Any(item => item.CPF == CPF);
    }

    private static boolean isUniqueCRM(string CRM, var list_medicos) {
        return list_medicos.Any(item => item.CRM == CRM);
    }

    public static virtual void adicionarPaciente(var paciente, var list) {
        if ( isUniqueCPF(paciente.CPF, list) ) {
            list.Add(paciente);
        } else {
            throw new Exception("Já existe um CPF igual a esse no sistema.");
        }
    }

    public static override void adicionarMedico(var medico, var list) {
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