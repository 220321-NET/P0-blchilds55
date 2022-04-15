namespace Models;

public class Product : CommonData
{
    private string _productName = "";
    private int _productAmount = 0;

    public Product(string product)
    {
        _productName = product;
    }

    public string getName
    {
        get => _productName;
    }

    public int Amount 
    { 
        get => _productAmount; 
        set
        {
            _productAmount = value;
        } 
    }
}