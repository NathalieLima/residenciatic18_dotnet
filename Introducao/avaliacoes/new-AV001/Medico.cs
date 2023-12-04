namespace Classes;

class Medico : Pessoa
{
    protected string crm;

    public string CRM 
    { 
        get { return this.crm; }
        set 
        {
            if ( Utilities.isEmptyValue(value) ) {
                throw new Exception("Este campo não aceita valores vazios ou nulos.");
            } else {
                this.crm = value;
            }
        }
    }
}