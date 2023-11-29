namespace Classes;

public class Aluno 
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno() {
        this.Nome = "Fulano";
        this.Idade = 15;
    }
}