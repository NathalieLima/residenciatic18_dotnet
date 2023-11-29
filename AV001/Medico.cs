namespace Classes;

class Medico : Pessoa
{
    private string CRM;

    public override DateTime DataNascimento 
    {
        get { return this.data_nascimento; }
        set 
        {
            DateTime data;
            Boolean is_valid_date = DateTime.TryParse(value, out data);

            if (!is_valid_date)
            {
                throw new Exception("Data inválida! Insira uma válida para o médico.");
            } else {
                this.data_nascimento = value;
            }
        }
    }

    public string CRM 
    { 
        get { return this.CRM; }
        set 
        {
            if ( isEmptyField(value) ) {
                throw new Exception("Este campo não aceita valores vazios.");
            } else {
                this.CRM = value;
            }
        }
    }
}