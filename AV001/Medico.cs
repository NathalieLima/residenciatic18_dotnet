namespace Classes;

class Medico : Pessoa
{
    private string CRM;

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