namespace Classes;

static class GeradorRelatorio
{
    public static void getMedicosIdades(int min, int max, List<Medico> medicos_list) {
        medicos_list.Where(item => item.Idade >= min && item.Idade <= max)
        .ToList()
        .ForEach(item => Console.WriteLine($"Médico {item.Nome}: {item.Idade} anos");
        )
    }
}