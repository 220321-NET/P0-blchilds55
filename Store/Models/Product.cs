namespace Models;

public class Product : CommonData
{
    private string _productName = "";

    public Product(string product)
    {
        _productName = product;
    }

    public string getName
    {
        get => _productName;
    }
}