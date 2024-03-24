namespace ZadanieKontenery;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsDangerous { get; private set; }
    public LiquidContainer(int height, double weight, int depth, double maxLoadWeight, bool isdangerous) : base(height, weight, depth, "L", maxLoadWeight)
    {
        IsDangerous = isdangerous;
    }

    public override void UnloadContainer()
    {
        LoadWeight = 0;
        Console.WriteLine($"Container {SerialNumber} successfully unloaded");
    }

    public override void LoadContainer(double weight)
    {
        double maxAlowedWeight;
        if (IsDangerous)
        {
            maxAlowedWeight = MaxLoadWeight * 0.5;
        }
        else
        {
            maxAlowedWeight = MaxLoadWeight * 0.9;
        }

        if (weight > maxAlowedWeight)
        {
            throw new OverfillException("Weight over the limit");
        }
        LoadWeight = weight;
        Console.WriteLine($"Container {SerialNumber} successfully loaded");
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard in liquid container {SerialNumber}: {message}");
    }

    public override string ToString()
    {
        return $"{SerialNumber}, {Height}x{Depth}, weight: {Weight}, cargo weight: {LoadWeight}, max cargo weight: {MaxLoadWeight}, is dangerous: {IsDangerous}";
    }
}