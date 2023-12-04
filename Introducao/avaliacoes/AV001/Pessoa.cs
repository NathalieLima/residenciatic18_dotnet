namespace Classes;

class Pessoa
{
    protected string nome;
    protected DateTime data_nascimento;
    protected string cpf;

    public string Nome { get; set; }
    
    public virtual DateTime DataNascimento { get; set; }

    public string CPF 
    { 
        get { return this.cpf; }
        set 
        {
            var tupla_erro = isValidCPF(value);

            if ( !tupla_erro.erro ) {
                this.cpf = value;
            } else {
                throw new Exception(tupla_erro.message);
            }
        }
    }
}