namespace Classes;

class Pessoa
{
    private string nome;
    private DateTime data_nascimento;
    private string cpf;

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