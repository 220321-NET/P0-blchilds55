namespace Models;

public class Cart : CommonData
{
    public List<Product> currentCart { get; set; } = new List<Product>();
}