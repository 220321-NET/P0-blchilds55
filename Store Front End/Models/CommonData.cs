namespace Models;
using System.Text.Json.Serialization;

public abstract class CommonData
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}