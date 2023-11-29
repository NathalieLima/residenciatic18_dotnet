namespace Classes;

static class GeradorRelatorio
{
    public static void getMedicosIdades(int min, int max, List<Medico> medicos_list) {
        medicos_list.Where(item => item.Idade >= min && item.Idade <= max)
        .ToList()
        .ForEach(item => Console.WriteLine($"Médico {item.Nome}: {item.Idade} anos"));
    }

    public static void getPacientesIdades(int min, int max, List<Paciente> pacientes_list) {
        pacientes_list.Where(item => item.Idade >= min && item.Idade <= max)
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}: {item.Idade} anos"));
    }

    public static void getPacientesBySexo(string sexo, List<Paciente> pacientes_list) {
        pacientes_list.Where(item => item.Sexo == sexo)
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}"));
    }

    public static void getPacientesOrderByNome(string sexo, List<Paciente> pacientes_list) {
        pacientes_list.OrderBy(item => item.Nome)
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}"));
    }

    public static void getPacientesBySintomas(string sintomas, List<Paciente> pacientes_list) {
        pacientes_list.Where(item => item.Contains(sintomas))
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}"));
    }

    public static void getAniversariantesMes(int mes, List<Paciente> pacientes_list, List<Medico> medicos_list) {
        pacientes_list.Where(item => item.DataNascimento.Month == mes)
        .ToList()
        .ForEach(item => Console.WriteLine($"Paciente {item.Nome}"));
    }
}