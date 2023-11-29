using Utilities;

class Pessoa
{
    private string nome;
    private DateTime data_nascimento;
    private string CPF;

    public string Nome { get; set; }
    
    public virtual DateTime DataNascimento { get; set; }

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
}