using Utilities;

class Paciente
{
    private string nome;
    private DateTime data_nascimento;
    private string CPF;
    private string CRM;
    private List<string> sintomas;

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
    public int MyProperty { get; set; }
    public int MyProperty { get; set; }
}