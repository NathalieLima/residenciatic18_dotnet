namespace Classes;

public class Product 
{
    private string code;
    private string name;
    private double price;
    private int amount;

    public string Code 
    { 
        get { return this.code; }
        set 
        { 
            if ( value == null ) {
                throw new Exception("Este campo não aceita valores nulos.");
            } else {
                this.code = value;
            }
         }
    }

    public string Name 
    { 
        get { return this.name; }
        set { this.name = value; }
    }

    public double Price 
    { 
        get { return this.price; }
        set 
        { 
            if (value <= 0) {
                throw new Exception("Entre com um valor acima de 0.0 unidades monetárias.");
            } else {
                this.price = value;
            }
        }
    }

    public int Amount 
    { 
        get { return this.amount; }
        set 
        { 
            if (value < 0) {
                throw new Exception("Valores negativos não são permitidos.");
            } else {
                this.amount = value;
            }
        }
    }
}