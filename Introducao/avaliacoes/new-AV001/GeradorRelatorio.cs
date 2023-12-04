namespace Classes;

static class GeradorRelatorio
{
    public static void getMedicosIdades(int min, int max, List<Medico> medicos_list) {
        medicos_list.Where(item => item.calcularIdade() >= min && item.calcularIdade() <= max)
        .ToList()
        .ForEach(item => Console.WriteLine($"Médico {item.Nome}: {item.calcularIdade()} anos"));
    }

    public static void getPacientesIdades(int min, int max, List<Paciente> pacientes_list) {
        pacientes_list.Where(item => item.calcularIdade() >= min && item.calcularIdade() <= max)
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}: {item.calcularIdade()} anos"));
    }

    public static void getPacientesBySexo(string sexo, List<Paciente> pacientes_list) {
        pacientes_list.Where(item => item.Sexo == sexo)
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}"));
    }

    public static void getPacientesOrderByNome(List<Paciente> pacientes_list) {
        pacientes_list.OrderBy(item => item.Nome)
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}"));
    }

    public static void getPacientesBySintomas(string sintomas, List<Paciente> pacientes_list) {
        pacientes_list.Where(item => item.Sintomas.Contains(sintomas))
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}"));
    }

    public static void getAniversariantesMes(int mes, List<Pessoa> list) {
        list.Where(item => item.DataNascimento.Month == mes)
        .ToList()
        .ForEach(item => Console.WriteLine($"Pessoa {item.Nome}"));
    }
}