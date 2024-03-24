namespace ZadanieKontenery;

public class RefrigeratedContainer : Container
{
    public Product ProductObject { get; private set; }
    public double ContainerTemperature { get; private set; }
    public RefrigeratedContainer(int height, double weight, int depth, double maxLoadWeight, Product product, double containerTemperature) : base(height, weight, depth, "C", maxLoadWeight)
    {
        ProductObject = product;
        ContainerTemperature = containerTemperature;
        if (ContainerTemperature < ProductObject.RequiredTemperature)
        {
            Console.WriteLine($"Valid container temperature, changed to correct temperature: {ProductObject.RequiredTemperature}");
            ContainerTemperature = ProductObject.RequiredTemperature;
        }
    }

    public override void UnloadContainer()
    {
        LoadWeight = 0;
        Console.WriteLine($"Container {SerialNumber} successfully unloaded");
    }

    public override void LoadContainer(double weight)
    {
        if (weight > MaxLoadWeight)
        {
            throw new OverfillException("Weight over the limit");
        }
        LoadWeight = weight;
        Console.WriteLine($"Container {SerialNumber} successfully loaded - {ProductObject.Name}");
    }

    public override string ToString()
    {
        return $"{SerialNumber}, {Height}x{Depth}, weight: {Weight}, cargo weight: {LoadWeight}, max cargo weight: {MaxLoadWeight}, loaded product: {ProductObject.Name}, product required temp: {ProductObject.RequiredTemperature}, temp in container: {ContainerTemperature}";
    }
}
