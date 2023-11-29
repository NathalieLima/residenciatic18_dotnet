namespace Classes;

public class VeiculoModificado
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }

    public int IdadeVeiculo => DateTime.Now.Year - this.Ano;
}