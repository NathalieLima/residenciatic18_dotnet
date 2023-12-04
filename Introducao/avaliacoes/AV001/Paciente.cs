namespace Classes;

class Paciente : Pessoa
{
    private string sexo;
    private string sintomas;

    public override DateTime DataNascimento 
    {
        get { return this.data_nascimento; }
        set 
        {
            DateTime data;
            Boolean is_valid_date = DateTime.TryParse(value, out data);

            if (!is_valid_date)
            {
                throw new Exception("Data inválida! Insira uma válida para o paciente.");
            } else {
                this.data_nascimento = value;
            }
        }
    }

    public string Sexo 
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

    public string Sintomas { get; set; }
}