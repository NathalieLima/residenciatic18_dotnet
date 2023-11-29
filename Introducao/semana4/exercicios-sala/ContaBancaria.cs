namespace Classes;

class ContaBancaria 
{
    public double Saldo 
    { 
        get { return Saldo; }
        set 
        {
            if (value <= 0) {
                throw new ArgumentException("Saldo não pode ser negativo");
            } else {
                this.Saldo = value;
            }
        }
    }
}