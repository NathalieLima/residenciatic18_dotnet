using Utilities;

class Paciente : Pessoa
{
    private string sexo;
    private string sintomas;

    public string sexo 
    {
        get { return this.sexo; }
        set 
        {
            if (value != "feminimo" && value != "masculino") {
                throw new Exception("Insira um sexo válido: ou 'feminino', ou 'masculino'.");
            } else {
                this.sexo = value;
            }
        }
    }

    public string sintomas { get; set; }
}