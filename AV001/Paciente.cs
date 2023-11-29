using Utilities;

class Paciente
{
    private string nome;
    private DateTime data_nascimento;
    private string CPF;
    private string sexo;
    private string sintomas;

    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF 
    { 
        get { return this.CPF; }
        set 
        {
            var tupla_erro = isValidCPF(value);

            if ( !tupla_erro.erro ) {
                this.CPF = value;
            } else {
                throw new Exception(tupla_erro.message);
            }
        }
    }
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