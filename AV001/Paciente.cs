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
        get;
        set 
        {
            try {
                isValidCPF(value);
            }
            catch (Exception error) {
                return error.Message;
            } 
        }
    }
    public int MyProperty { get; set; }
    public int MyProperty { get; set; }
}