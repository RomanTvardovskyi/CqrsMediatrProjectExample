namespace CqrsMediatrProject.Models;

public class Product
{
    public Guid ProductId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
}