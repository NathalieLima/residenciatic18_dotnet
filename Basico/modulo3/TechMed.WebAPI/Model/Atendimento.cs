namespace Model.TechMed.WebAPI;
public class Atendimento{
    public int AtendimentoId {get; set;}
    public DateTime DataHora {get; set;}
    public int MedicoId {get; set;}
    public required Medico Medico {get; set;}
}
