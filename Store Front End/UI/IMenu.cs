namespace UI;
public interface IMenu
{
    public void Start();
    public void Start(HttpService httpService);
    public void Start(HttpService httpService, Customer value1);
}
