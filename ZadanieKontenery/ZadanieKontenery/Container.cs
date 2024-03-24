namespace ZadanieKontenery;

public abstract class Container 
{
    protected static int Counter = 0;
    public double LoadWeight { get; protected set; }
    protected int Height { get; set; }
    public double Weight { get; protected set; }
    protected int Depth { get; set; }
    public string SerialNumber { get; protected set; }
    protected double MaxLoadWeight { get; set; }

    protected Container( int height, double weight, int depth, string prefix, double maxLoadWeight)
    {
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = GenerateSerialNumber(prefix);
        MaxLoadWeight = maxLoadWeight;
    }

    private string GenerateSerialNumber(string prefix)
    {
        Counter++;
        string serialnumber = "KON-" + prefix + "-" + Counter;
        return serialnumber;
    }

    public abstract void UnloadContainer();
    public abstract void LoadContainer(double weight);
}