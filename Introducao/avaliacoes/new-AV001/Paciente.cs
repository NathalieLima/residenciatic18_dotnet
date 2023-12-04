namespace Classes;

class Paciente : Pessoa
{
    private string sexo;
    private string sintomas;

    public string Sexo 
    {
        get { return this.sexo; }
        set 
        {
            if (value == "feminino" || value == "masculino") {
                this.sexo = value;
            } else {
                throw new Exception("Insira um sexo válido: ou 'feminino', ou 'masculino'.");
            }
        }
    }

    public string Sintomas { get; set; }
}