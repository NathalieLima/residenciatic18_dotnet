namespace TesteNameSpace;

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
                throw new ArgumentNullException("Este campo não aceita valores nulos ou vazios.");
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
        set { this.price = value; }
    }

    public int Amount 
    { 
        get { return this.amount; }
        set { this.amount = value; }
    }
}