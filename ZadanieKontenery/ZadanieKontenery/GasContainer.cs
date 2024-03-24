namespace ZadanieKontenery;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }


    public GasContainer(int height, double weight, int depth, double maxLoadWeight, double pressure) : base(height, weight, depth, "G", maxLoadWeight)
    {
        Pressure = pressure;
    }

    public override void UnloadContainer()
    {
        LoadWeight = LoadWeight * 0.05;
        Console.WriteLine($"Container {SerialNumber} successfully unloaded");
    }

    public override void LoadContainer(double weight)
    {
        if (weight > MaxLoadWeight)
        {
            throw new OverfillException("Weight over the limit");
        }
        LoadWeight = weight;
        Console.WriteLine($"Container {SerialNumber} successfully loaded");
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard in gas container {SerialNumber}: {message}");
    }

    public override string ToString()
    {
        return
            $"{SerialNumber}, {Height}x{Depth}, weight: {Weight}, cargo weight: {LoadWeight}, max cargo weight: {MaxLoadWeight}, pressure: {Pressure}";
    }
} 