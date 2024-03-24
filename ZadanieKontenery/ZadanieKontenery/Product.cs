namespace ZadanieKontenery;

public class Product
{
    public string Name { get; set; }
    public double RequiredTemperature { get; set; }

    public Product(string name, double requiredTemperature)
    {
        Name = name;
        RequiredTemperature = requiredTemperature;
    }
}